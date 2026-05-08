using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IAssessmentRepository
    {
        Task AddAsync(Assessment assessment);

        Task<List<Assessment>> GetAllAsync();

        Task<List<Assessment>>
            GetByStudentIdAsync(int studentId);

        Task<List<Assessment>>
            GetByCourseIdAsync(int courseId);

        Task<Assessment?>
            GetByIdAsync(int id);
    }
}