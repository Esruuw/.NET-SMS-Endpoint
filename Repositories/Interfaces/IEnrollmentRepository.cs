using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment?> GetByIdAsync(int id);

        Task<List<Enrollment>> GetAllAsync();

        Task<bool> ExistsAsync(int studentId, int courseId);

        Task AddAsync(Enrollment enrollment);
    }
}
