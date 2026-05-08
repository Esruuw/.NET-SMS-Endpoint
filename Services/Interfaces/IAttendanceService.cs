using StudentApi.Models;

namespace StudentApi.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<List<AttendanceDto>> GetAllAsync();

        Task CreateAsync(CreateAttendanceDto dto);

        Task<List<AttendanceDto>>GetByStudentIdAsync(int studentId);

        Task<List<AttendanceDto>>GetByClassIdAsync(int classId);

        Task<AttendanceStatisticsDto>GetStatisticsAsync(int studentId);
    }
}