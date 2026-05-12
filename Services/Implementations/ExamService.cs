using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IClassRepository _classRepo;

        public ExamService(IExamRepository examRepo, ICourseRepository courseRepo, IClassRepository classRepo)
        {
            _examRepo = examRepo;
            _courseRepo = courseRepo;
            _classRepo = classRepo;
        }

        public async Task CreateAsync(CreateExamDto dto)
        {
            var course = await _courseRepo.GetByIdAsync(dto.CourseId)
                ?? throw new Exception("Course not found");

            if (dto.ClassId.HasValue)
            {
                var cls = await _classRepo.GetByIdAsync(dto.ClassId.Value)
                    ?? throw new Exception("Class not found");
            }

            var exam = new Exam
            {
                CourseId = dto.CourseId,
                ClassId = dto.ClassId,
                ExamDate = dto.ExamDate,
                DurationMinutes = dto.DurationMinutes,
                TotalMarks = dto.TotalMarks,
                Description = dto.Description
            };

            await _examRepo.AddAsync(exam);
        }

        public async Task DeleteAsync(int id)
        {
            await _examRepo.DeleteAsync(id);
        }

        public async Task<List<ExamDto>> GetAllAsync()
        {
            var list = await _examRepo.GetAllAsync();

            return list.Select(e => new ExamDto
            {
                ExamId = e.ExamId,
                CourseId = e.CourseId,
                ClassId = e.ClassId,
                ClassName = e.Class?.ClassName,
                CourseName = e.Course?.CourseName,
                ExamDate = e.ExamDate,
                DurationMinutes = e.DurationMinutes,
                TotalMarks = e.TotalMarks,
                Description = e.Description
            }).ToList();
        }

        public async Task<List<ExamDto>> GetByClassIdAsync(int classId)
        {
            var list = await _examRepo.GetByClassIdAsync(classId);

            return list.Select(e => new ExamDto
            {
                ExamId = e.ExamId,
                CourseId = e.CourseId,
                CourseName = e.Course?.CourseName,
                ExamDate = e.ExamDate,
                DurationMinutes = e.DurationMinutes,
                TotalMarks = e.TotalMarks,
                Description = e.Description
            }).ToList();
        }

        public async Task<ExamDto?> GetByIdAsync(int id)
        {
            var e = await _examRepo.GetByIdAsync(id);
            if (e == null) return null;

            return new ExamDto
            {
                ExamId = e.ExamId,
                CourseId = e.CourseId,
                CourseName = e.Course?.CourseName,
                ClassId = e.ClassId,
                ClassName = e.Class?.ClassName,
                ExamDate = e.ExamDate,
                DurationMinutes = e.DurationMinutes,
                TotalMarks = e.TotalMarks,
                Description = e.Description
            };
        }

        public async Task UpdateAsync(int id, UpdateExamDto dto)
        {
            var e = await _examRepo.GetByIdAsync(id);
            if (e == null) return;

            e.ExamDate = dto.ExamDate;
            e.DurationMinutes = dto.DurationMinutes;
            e.TotalMarks = dto.TotalMarks;
            e.Description = dto.Description;

            await _examRepo.UpdateAsync(e);
        }
    }
}
