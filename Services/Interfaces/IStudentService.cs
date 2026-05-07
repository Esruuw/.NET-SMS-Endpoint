namespace StudentApi.Services.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task CreateAsync(CreateStudentDto dto);
        Task UpdateAsync(int id, UpdateStudentDto dto);
        Task DeleteAsync(int id);
         Task<List<StudentDto>> SearchAsync(
        int? id,
        string? name,
        string? gender,
        int? classId);
    }
}