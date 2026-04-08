using StudentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(int id);
        Task<List<Student>> SearchStudent(int? id, string? name, string? department, string? phone);
    }
}
