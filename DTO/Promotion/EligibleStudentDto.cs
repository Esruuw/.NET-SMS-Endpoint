public class EligibleStudentDto
{
    public int StudentId { get; set; }
    public string? StudentName { get; set; }
    public double AverageScore { get; set; }
    public int FromClassId { get; set; }
    public int? ToClassId { get; set; }
}
