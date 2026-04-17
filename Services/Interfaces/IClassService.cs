
namespace StudentApi.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllAsync();
        Task<ClassDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateClassDto dto);
        Task UpdateAsync(int id, UpdateClassDto dto);
        Task DeleteAsync(int id);
    }
}