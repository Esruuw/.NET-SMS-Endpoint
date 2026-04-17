public class ClassDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public int GradeLevel { get; set; }
    public string? Section { get; set; }
    public string? AcademicYear { get; set; }

    public int? TeacherId { get; set; }
    public string? TeacherName { get; set; }
}