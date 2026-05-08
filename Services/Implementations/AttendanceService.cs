using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class AttendanceService
        : IAttendanceService
    {
        private readonly IAttendanceRepository _repository;

        public AttendanceService(
            IAttendanceRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AttendanceDto>>GetAllAsync()
        {
            var attendances =
                await _repository.GetAllAsync();

            return attendances.Select(a =>
                new AttendanceDto
                {
                    AttendanceId = a.AttendanceId,

                    StudentName =
                        a.Student!.FirstName + " " +
                        a.Student.LastName,

                    CourseName =
                        a.Timetable!.Course!.CourseName,

                    Date = a.Date,

                    Status = a.Status,

                    Remark = a.Remark
                }).ToList();
        }

        public async Task CreateAsync(CreateAttendanceDto dto)
        {
            bool exists =
                await _repository.ExistsAsync(
                    dto.StudentId,
                    dto.TimetableId,
                    dto.Date);

            if (exists)
            {
                throw new Exception(
                    "Attendance already marked");
            }

            var attendance = new Attendance
            {
                StudentId = dto.StudentId,

                TimetableId = dto.TimetableId,

                Date = dto.Date,

                Status = dto.Status,

                Remark = dto.Remark
            };

            await _repository.AddAsync(attendance);
        }

        public async Task<List<AttendanceDto>>GetByStudentIdAsync(int studentId)
        {
            var attendances =
                await _repository
                    .GetByStudentIdAsync(studentId);

            return attendances.Select(a =>
                new AttendanceDto
                {
                    AttendanceId = a.AttendanceId,

                    StudentName =
                        a.Student!.FirstName + " " +
                        a.Student.LastName,

                    CourseName =
                        a.Timetable!.Course!.CourseName,

                    Date = a.Date,

                    Status = a.Status,

                    Remark = a.Remark
                }).ToList();
        }

        public async Task<List<AttendanceDto>>GetByClassIdAsync(int classId)
        {
            var attendances =
                await _repository
                    .GetByClassIdAsync(classId);

            return attendances.Select(a =>
                new AttendanceDto
                {
                    AttendanceId = a.AttendanceId,

                    StudentName =
                        a.Student!.FirstName + " " +
                        a.Student.LastName,

                    CourseName =
                        a.Timetable!.Course!.CourseName,

                    Date = a.Date,

                    Status = a.Status,

                    Remark = a.Remark
                }).ToList();
        }

        public async Task<AttendanceStatisticsDto>GetStatisticsAsync(int studentId)
        {
            var attendances =
                await _repository
                    .GetByStudentIdAsync(studentId);

            int total =
                attendances.Count;

            int present =
                attendances.Count(a =>
                    a.Status == "Present");

            int absent =
                attendances.Count(a =>
                    a.Status == "Absent");

            int late =
                attendances.Count(a =>
                    a.Status == "Late");

            double percentage =
                total > 0
                ? (double)present / total * 100
                : 0;

            return new AttendanceStatisticsDto
            {
                TotalDays = total,

                Present = present,

                Absent = absent,

                Late = late,

                AttendancePercentage =
                    Math.Round(percentage, 2)
            };
        }
    }
}