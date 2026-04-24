using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _repo;
    private readonly IEnrollmentRepository _enrollmentRepo;

    public GradeService(IGradeRepository repo, IEnrollmentRepository enrollmentRepo)
    {
        _repo = repo;
        _enrollmentRepo = enrollmentRepo;
    }

    public async Task<GradeDto> AddGradeAsync(CreateGradeDto dto)
    {
        var enrollment = await _enrollmentRepo.GetByIdAsync(dto.EnrollmentId)
            ?? throw new Exception("Enrollment not found");

        var grade = new Grade
        {
            EnrollmentId = dto.EnrollmentId,
            Score = dto.Score,
            Remark = dto.Remark
        };

        await _repo.AddAsync(grade);

        return new GradeDto
        {
            GradeId = grade.GradeId,
            StudentId = enrollment.StudentId,
            StudentName = $"{enrollment.Student!.FirstName} {enrollment.Student.LastName}",
            CourseId = enrollment.CourseId,
            CourseName = enrollment.Course!.CourseName,
            Score = grade.Score,
            Remark = grade.Remark,
            CreatedAt = DateTime.Now
        };
    }

    public async Task<List<GradeDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        return list.Select(g => new GradeDto
        {
            GradeId = g.GradeId,
            StudentId = g.Enrollment!.StudentId,
            StudentName = $"{g.Enrollment.Student!.FirstName} {g.Enrollment.Student.LastName}",
            CourseId = g.Enrollment.CourseId,
            CourseName = g.Enrollment.Course!.CourseName,
            Score = g.Score,
            Remark = g.Remark,
            CreatedAt = DateTime.Now
        }).ToList();
    }
}
