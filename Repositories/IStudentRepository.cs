using StudentApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllAsync();
        Task<Student?> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<List<Student>> SearchAsync(int? id, string? name, string? department, string? phone);
    }
}
