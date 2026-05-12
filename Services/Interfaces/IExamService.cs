using StudentApi.Models;

public interface IExamService
{
    Task<List<ExamDto>> GetAllAsync();
    Task<List<ExamDto>> GetByClassIdAsync(int classId);
    Task<ExamDto?> GetByIdAsync(int id);
    Task CreateAsync(CreateExamDto dto);
    Task UpdateAsync(int id, UpdateExamDto dto);
    Task DeleteAsync(int id);
}
