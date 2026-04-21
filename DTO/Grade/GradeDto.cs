public class GradeDto
{
    public int GradeId { get; set; }

    public int StudentId { get; set; }
    public string? StudentName { get; set; }

    public int CourseId { get; set; }
    public string? CourseName { get; set; }

    public double Score { get; set; }

    public string? Remark { get; set; }

    public DateTime CreatedAt { get; set; }
}
