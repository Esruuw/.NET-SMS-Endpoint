public class ClassStatisticsDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = "";

    public int TotalStudents { get; set; }
    public int Passed { get; set; }
    public int Failed { get; set; }

    public double PassRate { get; set; }

    public string TopStudent { get; set; } = "";
}