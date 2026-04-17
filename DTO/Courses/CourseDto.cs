namespace StudentApi.DTOs.Courses;

public class CourseDto
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int? GradeLevel { get; set; }
}