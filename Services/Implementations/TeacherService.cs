using StudentApi.Models;
using StudentApi.Services.Interfaces;


public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }

    public async Task<List<TeacherDto>> GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync();

        return teachers.Select(s => new TeacherDto
        {
            TeacherId = s.TeacherId,
            FullName = s.FirstName + " " + s.LastName,
            Gender = s.Gender,
            Phone = s.Phone,
            SubjectSpecialization = s.SubjectSpecialization,

        }).ToList();
    }

    public async Task<TeacherDto?> GetByIdAsync(int id)
    {
        var s = await _teacherRepository.GetByIdAsync(id);
        if (s == null) return null;

        return new TeacherDto
        {
            FullName = s.FirstName + " " + s.LastName,
            Gender = s.Gender,
            Phone = s.Phone,
            SubjectSpecialization = s.SubjectSpecialization,
        };
    }

    public async Task CreateAsync(CreateTeacherDto dto)
    {
        var teacher = new Teacher
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            Address = dto.Address,
            Phone = dto.Phone,
            Email = dto.Email,
            SubjectSpecialization = dto.SubjectSpecialization,

        };

        await _teacherRepository.AddAsync(teacher);
    }

    public async Task UpdateAsync(int id, UpdateTeacherDto dto)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        if (teacher == null) return;

        teacher.LastName = dto.LastName;
        teacher.Gender = dto.Gender;
        teacher.Address = dto.Address;
        teacher.Phone = dto.Phone;
        teacher.Status = dto.Status;

        await _teacherRepository.UpdateAsync(teacher);
    }

    public async Task DeleteAsync(int id)
    {
        await _teacherRepository.DeleteAsync(id);
    }
}
