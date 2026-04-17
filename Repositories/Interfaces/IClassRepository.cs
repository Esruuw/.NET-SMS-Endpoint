using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllAsync();
        Task<Class?> GetByIdAsync(int id);
        Task AddAsync(Class entity);
        Task UpdateAsync(Class entity);
        Task DeleteAsync(int id);
    }
}