using System;

public class CreateExamDto
{
    public int? ClassId { get; set; }
    public int CourseId { get; set; }
    public DateTime ExamDate { get; set; }
    public int DurationMinutes { get; set; }
    public double TotalMarks { get; set; }
    public string? Description { get; set; }
}
