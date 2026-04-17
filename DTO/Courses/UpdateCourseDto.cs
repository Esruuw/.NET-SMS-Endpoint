namespace StudentApi.DTOs.Courses;

public class UpdateCourseDto
{
    public string SubjectName { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int? GradeLevel { get; set; }
    public object CourseName { get; internal set; }
}