public class UpdateClassDto
{
    public string ClassName { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public string? Section { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int? TeacherId { get; set; }
}