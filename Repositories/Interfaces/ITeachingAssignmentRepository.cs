public interface ITeachingAssignmentRepository
{
    Task<bool> ExistsAsync(int teacherId, int courseId);
    Task<List<TeachingAssignment>> GetAllAsync();
    Task AddAsync(TeachingAssignment entity);
}
