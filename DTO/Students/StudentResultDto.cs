public class StudentResultDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;

    public double AverageScore { get; set; }
    public int Rank { get; set; }

    public List<CourseResultDto> Courses { get; set; } = new();
}
