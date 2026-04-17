public class TeacherDto
{
    public int TeacherId { get; set; }

    public string FullName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }

    public string SubjectSpecialization { get; set; } = string.Empty;
}