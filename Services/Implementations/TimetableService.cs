using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class TimetableService : ITimetableService
    {
        private readonly ITimetableRepository _repository;

        public TimetableService(
            ITimetableRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TimetableDto>> GetAllAsync()
        {
            var timetables =
                await _repository.GetAllAsync();

            return timetables.Select(t => new TimetableDto
            {
                TimetableId = t.TimetableId,

                ClassName = t.Class!.ClassName,

                CourseName = t.Course!.CourseName,

                TeacherName =
                    t.Teacher!.FirstName + " " +
                    t.Teacher.LastName,

                DayOfWeek = t.DayOfWeek,

                ScheduleDate = t.ScheduleDate,

                Semester = t.Semester,

                StartTime = t.StartTime,

                EndTime = t.EndTime

            }).ToList();
        }

        public async Task<List<TimetableDto>>
            GetByClassIdAsync(int classId)
        {
            var timetables =
                await _repository
                    .GetByClassIdAsync(classId);

            return timetables.Select(t => new TimetableDto
            {
                TimetableId = t.TimetableId,

                ClassName = t.Class!.ClassName,

                CourseName = t.Course!.CourseName,

                TeacherName =
                    t.Teacher!.FirstName + " " +
                    t.Teacher.LastName,

                DayOfWeek = t.DayOfWeek,

                ScheduleDate = t.ScheduleDate,

                Semester = t.Semester,

                StartTime = t.StartTime,

                EndTime = t.EndTime

            }).ToList();
        }

        public async Task<List<TimetableDto>>
            GetByTeacherIdAsync(int teacherId)
        {
            var timetables =
                await _repository
                    .GetByTeacherIdAsync(teacherId);

            return timetables.Select(t => new TimetableDto
            {
                TimetableId = t.TimetableId,

                ClassName = t.Class!.ClassName,

                CourseName = t.Course!.CourseName,

                TeacherName =
                    t.Teacher!.FirstName + " " +
                    t.Teacher.LastName,

                DayOfWeek = t.DayOfWeek,

                ScheduleDate = t.ScheduleDate,

                Semester = t.Semester,

                StartTime = t.StartTime,

                EndTime = t.EndTime

            }).ToList();
        }

        public async Task CreateAsync(CreateTimetableDto dto)
        {
            var timetable = new Timetable
            {
                ClassId = dto.ClassId,

                CourseId = dto.CourseId,

                TeacherId = dto.TeacherId,

                DayOfWeek = dto.DayOfWeek,

                ScheduleDate = dto.ScheduleDate,

                Semester = dto.Semester,

                StartTime = dto.StartTime,

                EndTime = dto.EndTime
            };

            await _repository.AddAsync(timetable);
        }
    }
}