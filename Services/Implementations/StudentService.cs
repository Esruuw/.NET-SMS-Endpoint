using StudentApi.Models;
using StudentApi.Services.Interfaces;
namespace StudentApi.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAllAsync();

            return students.Select(s => new StudentDto
            {
                StudentId = s.StudentId,
                FullName = s.FirstName + " " + s.LastName,
                Gender = s.Gender,
                DateOfBirth = s.DateOfBirth,
                Address = s.Address,
                Phone = s.Phone,
                ClassId = s.ClassId,
                ClassName = s.Class?.ClassName,
                ParentName = s.ParentName,
                ParentPhone = s.ParentPhone,
                Status = s.Status
            }).ToList();
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var s = await _studentRepository.GetByIdAsync(id);
            if (s == null) return null;

            return new StudentDto
            {
                StudentId = s.StudentId,
                FullName = s.FirstName + " " + s.LastName,
                Gender = s.Gender,
                DateOfBirth = s.DateOfBirth,
                Address = s.Address,
                Phone = s.Phone,
                ClassId = s.ClassId,
                ClassName = s.Class?.ClassName,
                ParentName = s.ParentName,
                ParentPhone = s.ParentPhone,
                Status = s.Status
            };
        }

        public async Task CreateAsync(CreateStudentDto dto)
        {
            var student = new Student
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Phone = dto.Phone,
                ClassId = dto.ClassId,
                ParentName = dto.ParentName,
                ParentPhone = dto.ParentPhone
            };

            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateAsync(int id, UpdateStudentDto dto)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return;

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;
            student.Gender = dto.Gender;
            student.DateOfBirth = dto.DateOfBirth;
            student.Address = dto.Address;
            student.Phone = dto.Phone;
            student.ClassId = dto.ClassId;
            student.ParentName = dto.ParentName;
            student.ParentPhone = dto.ParentPhone;
            student.Status = dto.Status;

            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}