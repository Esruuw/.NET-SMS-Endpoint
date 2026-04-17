public class
CreateTeacherDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }

    public string SubjectSpecialization { get; set; } = string.Empty;

    public DateTime HireDate { get; set; } = DateTime.Now;

    public string? Address { get; set; }
}