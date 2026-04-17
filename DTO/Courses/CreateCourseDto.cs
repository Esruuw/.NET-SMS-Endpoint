
namespace StudentApi.DTOs.Courses;

public class CreateCourseDto
{
    public string SubjectName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int? GradeLevel { get; set; }
}