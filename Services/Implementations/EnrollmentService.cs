using StudentApi.DTOs;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;
public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repo;
    private readonly IStudentRepository _studentRepo;
    private readonly ICourseRepository _courseRepo;

    public EnrollmentService(
        IEnrollmentRepository repo,
        IStudentRepository studentRepo,
        ICourseRepository courseRepo)
    {
        _repo = repo;
        _studentRepo = studentRepo;
        _courseRepo = courseRepo;
    }

    public async Task<EnrollmentDto> EnrollStudentAsync(CreateEnrollmentDto dto)
    {
        var student = await _studentRepo.GetByIdAsync(dto.StudentId)
            ?? throw new Exception("Student not found");

        var course = await _courseRepo.GetByIdAsync(dto.CourseId)
            ?? throw new Exception("Course not found");

        if (await _repo.ExistsAsync(dto.StudentId, dto.CourseId))
            throw new Exception("Student already enrolled");

        var enrollment = new Enrollment
        {
            StudentId = dto.StudentId,
            CourseId = dto.CourseId,
            EnrolledAt = DateTime.Now,
            Status = "Active"
        };

        await _repo.AddAsync(enrollment);

        return new EnrollmentDto
        {
            EnrollmentId = enrollment.EnrollmentId,
            StudentId = student.StudentId,
            StudentName = $"{student.FirstName} {student.LastName}",
            CourseId = course.CourseId,
            CourseName = course.CourseName,
            EnrolledAt = enrollment.EnrolledAt,
            Status = enrollment.Status
        };
    }

    public async Task<List<EnrollmentDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        return list.Select(e => new EnrollmentDto
        {
            EnrollmentId = e.EnrollmentId,
            StudentId = e.StudentId,
            StudentName = $"{e.Student!.FirstName} {e.Student.LastName}",
            CourseId = e.CourseId,
            CourseName = e.Course!.CourseName,
            EnrolledAt = e.EnrolledAt,
            Status = e.Status
        }).ToList();
    }
}
