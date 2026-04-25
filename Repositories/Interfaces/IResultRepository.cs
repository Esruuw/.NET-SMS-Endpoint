using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<Class> GetClassWithStudentsAsync(int classId);
        Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
    }
}
