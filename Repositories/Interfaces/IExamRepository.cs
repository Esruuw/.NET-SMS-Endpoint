using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllAsync();
        Task<Exam?> GetByIdAsync(int id);
        Task<List<Exam>> GetByClassIdAsync(int classId);
        Task AddAsync(Exam entity);
        Task UpdateAsync(Exam entity);
        Task DeleteAsync(int id);
    }
}
