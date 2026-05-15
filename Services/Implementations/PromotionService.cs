using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class PromotionService : IPromotionService
    {
        private readonly IClassRepository _classRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly AppDbContext _db;
        private readonly IResultService _resultService;

        public PromotionService(IClassRepository classRepo, IStudentRepository studentRepo, AppDbContext db, IResultService resultService)
        {
            _classRepo = classRepo;
            _studentRepo = studentRepo;
            _db = db;
            _resultService = resultService;
        }

        public async Task PromoteClassAsync(int classId, string? targetAcademicYear = null, int? performedByUserId = null)
        {
            var fromClass = await _classRepo.GetByIdAsync(classId)
                ?? throw new Exception("Source class not found");

            var toGrade = fromClass.GradeLevel + 1;
            var targetYear = targetAcademicYear ?? fromClass.AcademicYear;

            // find target class (same section)
            var allClasses = await _classRepo.GetAllAsync();
            var toClass = allClasses.FirstOrDefault(c => c.GradeLevel == toGrade && c.Section == fromClass.Section && c.AcademicYear == targetYear);

            if (toClass == null)
            {
                // create target class
                toClass = new Class
                {
                    ClassName = $"Grade {toGrade} {fromClass.Section}",
                    GradeLevel = toGrade,
                    Section = fromClass.Section,
                    AcademicYear = targetYear,
                    TeacherId = null
                };

                await _classRepo.AddAsync(toClass);
                // refresh allClasses to get generated id
                allClasses = await _classRepo.GetAllAsync();
                toClass = allClasses.First(c => c.GradeLevel == toGrade && c.Section == fromClass.Section && c.AcademicYear == targetYear);
            }

            // get students in source class
            var students = await _studentRepo.SearchAsync(null, null, null, classId);

            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                foreach (var s in students)
                {
                    var fromClassId = s.ClassId;
                    s.ClassId = toClass.ClassId;
                    await _studentRepo.UpdateAsync(s);

                    var history = new PromotionHistory
                    {
                        StudentId = s.StudentId,
                        FromClassId = fromClassId,
                        ToClassId = toClass.ClassId,
                        PerformedByUserId = performedByUserId
                    };

                    await _db.PromotionHistories.AddAsync(history);
                }

                await _db.SaveChangesAsync();
                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task PromoteGradeAsync(int fromGradeLevel, int? toGradeLevel = null, string? section = null, string? targetAcademicYear = null, int? performedByUserId = null)
        {
            var allClasses = await _classRepo.GetAllAsync();
            var classes = allClasses.Where(c => c.GradeLevel == fromGradeLevel && (section == null || c.Section == section)).ToList();

            foreach (var cl in classes)
            {
                await PromoteClassAsync(cl.ClassId, targetAcademicYear, performedByUserId);
            }
        }

        public async Task PromoteStudentAsync(int studentId, int? targetClassId = null, string? targetAcademicYear = null, int? performedByUserId = null)
        {
            var student = await _studentRepo.GetByIdAsync(studentId)
                ?? throw new Exception("Student not found");

            var fromClass = await _classRepo.GetByIdAsync(student.ClassId)
                ?? throw new Exception("Student's class not found");

            Class? toClass = null;

            if (targetClassId.HasValue)
            {
                toClass = await _classRepo.GetByIdAsync(targetClassId.Value)
                    ?? throw new Exception("Target class not found");
            }
            else
            {
                var toGrade = fromClass.GradeLevel + 1;
                var targetYear = targetAcademicYear ?? fromClass.AcademicYear;

                var allClasses = await _classRepo.GetAllAsync();
                toClass = allClasses.FirstOrDefault(c => c.GradeLevel == toGrade && c.Section == fromClass.Section && c.AcademicYear == targetYear);

                if (toClass == null)
                {
                    toClass = new Class
                    {
                        ClassName = $"Grade {toGrade} {fromClass.Section}",
                        GradeLevel = toGrade,
                        Section = fromClass.Section,
                        AcademicYear = targetYear,
                        TeacherId = null
                    };

                    await _classRepo.AddAsync(toClass);
                    // refresh to get id
                    allClasses = await _classRepo.GetAllAsync();
                    toClass = allClasses.First(c => c.GradeLevel == toGrade && c.Section == fromClass.Section && c.AcademicYear == targetYear);
                }
            }

            using var tx = await _db.Database.BeginTransactionAsync();
            try
            {
                var prevClassId = student.ClassId;
                student.ClassId = toClass.ClassId;
                await _studentRepo.UpdateAsync(student);

                var history = new PromotionHistory
                {
                    StudentId = student.StudentId,
                    FromClassId = prevClassId,
                    ToClassId = toClass.ClassId,
                    PerformedByUserId = performedByUserId
                };

                await _db.PromotionHistories.AddAsync(history);
                await _db.SaveChangesAsync();
                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task<List<EligibleStudentDto>> GetEligibleStudentsAsync(PromotionQueryDto dto)
        {
            var fromClassId = dto.FromClassId;
            var minAvg = dto.MinimumAverage ?? 0.0;

            // Reuse existing ResultService logic to compute class results (averages per student)
            var classResult = await _resultService.GetClassResultAsync(fromClassId);

            var eligible = classResult.Students
                .Where(s => s.AverageScore >= minAvg)
                .Select(s => new EligibleStudentDto
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName,
                    AverageScore = s.AverageScore,
                    FromClassId = fromClassId,
                    ToClassId = dto.ToClassId
                })
                .ToList();

            return eligible;
        }
    }
}
