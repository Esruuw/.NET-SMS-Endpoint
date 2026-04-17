
namespace StudentApi.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetAllAsync();
        Task<TeacherDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateTeacherDto dto);
        Task UpdateAsync(int id, UpdateTeacherDto dto);
        Task DeleteAsync(int id);
    }
}