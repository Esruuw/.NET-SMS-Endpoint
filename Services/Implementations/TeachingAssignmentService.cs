using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;
// using StudentApi.Data;
public class TeachingAssignmentService : ITeachingAssignmentService
{
    private readonly ITeachingAssignmentRepository _repo;
    private readonly ITeacherRepository _teacherRepo;
    private readonly ICourseRepository _courseRepo;

    public TeachingAssignmentService(
        ITeachingAssignmentRepository repo,
        ITeacherRepository teacherRepo,
        ICourseRepository courseRepo)
    {
        _repo = repo;
        _teacherRepo = teacherRepo;
        _courseRepo = courseRepo;
    }

    public async Task<TeachingAssignmentDto> AssignAsync(CreateTeachingAssignmentDto dto)
    {
        var teacher = await _teacherRepo.GetByIdAsync(dto.TeacherId)
            ?? throw new Exception("Teacher not found");

        var course = await _courseRepo.GetByIdAsync(dto.CourseId)
            ?? throw new Exception("Course not found");

        if (await _repo.ExistsAsync(dto.TeacherId, dto.CourseId))
            throw new Exception("Already assigned");

        var entity = new TeachingAssignment
        {
            TeacherId = dto.TeacherId,
            CourseId = dto.CourseId
        };

        await _repo.AddAsync(entity);

        return new TeachingAssignmentDto
        {
            Id = entity.Id,
            TeacherId = teacher.TeacherId,
            TeacherName = $"{teacher.FirstName} {teacher.LastName}",
            CourseId = course.CourseId,
            CourseName = course.CourseName,
            AssignedAt = DateTime.Now
        };
    }

    public async Task<List<TeachingAssignmentDto>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        return list.Select(x => new TeachingAssignmentDto
        {
            Id = x.Id,
            TeacherId = x.TeacherId,
            TeacherName = $"{x.Teacher!.FirstName} {x.Teacher.LastName}",
            CourseId = x.CourseId,
            CourseName = x.Course!.CourseName,
            AssignedAt = DateTime.Now
        }).ToList();
    }
}
