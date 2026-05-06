public class StudentResultDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;

    public double AverageScore { get; set; }
    public int Rank { get; set; }
    public double TotalScore { get; set; }
    public int TotalCourses { get; set; }
    public bool IsPassed { get; set; } //whether student passed or not based on average score
    public string Status { get; set; } = ""; // "Passed", "Failed", "At Risk" based on average score
    public List<CourseResultDto> Courses { get; set; } = new();
}
