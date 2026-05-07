public interface ITimetableService
{
    Task<List<TimetableDto>> GetAllAsync();

    Task<List<TimetableDto>> GetByClassIdAsync(int classId);

    Task<List<TimetableDto>> GetByTeacherIdAsync(int teacherId);

    Task CreateAsync(CreateTimetableDto dto);
}