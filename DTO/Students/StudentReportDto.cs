public class StudentReportDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;

    public string ClassName { get; set; } = string.Empty;

    public double TotalScore { get; set; }
    public double AverageScore { get; set; }
    public int Rank { get; set; }
    public bool IsPassed { get; set; }
    public string Status { get; set; } = "";
    public List<CourseResultDto> Courses { get; set; } = new();
}
