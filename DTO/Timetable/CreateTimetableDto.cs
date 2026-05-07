public class CreateTimetableDto
{
    public int ClassId { get; set; }

    public int CourseId { get; set; }

    public int TeacherId { get; set; }

    public string DayOfWeek { get; set; } = string.Empty;
    public DateTime ScheduleDate { get; set; }
    public string Semester { get; set; } = string.Empty;
    public string StartTime { get; set; }

    public string EndTime { get; set; } 
}