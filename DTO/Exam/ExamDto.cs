using System;

public class ExamDto
{
    public int ExamId { get; set; }
    public int CourseId { get; set; }
    public int? ClassId { get; set; }
    public string? CourseName { get; set; }
    public string? ClassName { get; set; }
    public DateTime ExamDate { get; set; }
    public int DurationMinutes { get; set; }
    public double TotalMarks { get; set; }
    public string? Description { get; set; }
}
