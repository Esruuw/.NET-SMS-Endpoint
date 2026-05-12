using System;

public class UpdateExamDto
{
    public DateTime ExamDate { get; set; }
    public int DurationMinutes { get; set; }
    public double TotalMarks { get; set; }
    public string? Description { get; set; }
}
