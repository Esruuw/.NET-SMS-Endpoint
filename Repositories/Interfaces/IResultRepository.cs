using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<Class> GetClassWithStudentsAsync(int classId);
        Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId);
        Task<Student?> GetStudentWithClassAsync(int studentId);
        
        // New method to get assessments by student ID
        Task<List<Assessment>>GetAssessmentsByStudentIdAsync(int studentId);

    }
}
