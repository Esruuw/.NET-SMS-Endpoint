using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface ITimetableRepository
    {
        Task<List<Timetable>> GetAllAsync();

        Task<List<Timetable>> GetByClassIdAsync(int classId);

        Task<List<Timetable>> GetByTeacherIdAsync(int teacherId);

        Task AddAsync(Timetable timetable);
    }
}