namespace StudentApi.Models
{
    public class Timetable
    {
        public int TimetableId { get; set; }

        public int ClassId { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }
        public DateTime ScheduleDate { get; set; }

        public string Semester { get; set; } = string.Empty;
        public string DayOfWeek { get; set; } = string.Empty;

        public string StartTime { get; set; } = string.Empty;

        public string EndTime { get; set; } = string.Empty;

        public Class? Class { get; set; }

        public Course? Course { get; set; }

        public Teacher? Teacher { get; set; }
    }
}