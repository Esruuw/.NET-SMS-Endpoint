public interface IGradeRepository
{
    Task<Grade?> GetByIdAsync(int id);
    Task<List<Grade>> GetAllAsync();
    Task AddAsync(Grade grade);
}
