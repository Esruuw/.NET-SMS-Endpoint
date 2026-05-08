using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAllAsync();

        Task AddAsync(Attendance attendance);

        Task<List<Attendance>>GetByStudentIdAsync(int studentId);

        Task<List<Attendance>>GetByClassIdAsync(int classId);

        Task<bool> ExistsAsync(int studentId,int timetableId,DateTime date);
    }
}