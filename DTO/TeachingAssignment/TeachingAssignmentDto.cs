public class TeachingAssignmentDto
{
    public int Id { get; set; }

    public int TeacherId { get; set; }
    public string? TeacherName { get; set; }

    public int CourseId { get; set; }
    public string? CourseName { get; set; }

    public DateTime AssignedAt { get; set; }
}
