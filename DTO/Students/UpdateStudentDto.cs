public class UpdateStudentDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }
    public string? Phone { get; set; }

    public int ClassId { get; set; }
    public string? ParentName { get; set; }
    public string? ParentPhone { get; set; }

    public string Status { get; set; } = "Active";
    public DateTime AdmissionDate { get; set; }
}