public class TimetableDto
{
    public int TimetableId { get; set; }

    public string ClassName { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public string TeacherName { get; set; } = string.Empty;

    public string DayOfWeek { get; set; } = string.Empty;
    public DateTime ScheduleDate { get; set; }
    public string Semester { get; set; } = string.Empty;
    public string StartTime { get; set; }

    public string EndTime { get; set; }
}