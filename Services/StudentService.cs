using StudentApi.Models;
using StudentApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddStudent(Student student)
        {
            await _repository.AddAsync(student);
        }

        public async Task UpdateStudent(Student student)
        {
            await _repository.UpdateAsync(student);
        }

        public async Task DeleteStudent(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<Student>> SearchStudent(int? id, string? name, string? department, string? phone)
        {
            return await _repository.SearchAsync(id, name, department, phone);
        }
    }
}
