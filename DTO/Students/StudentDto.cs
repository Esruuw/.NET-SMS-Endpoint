public class StudentDto
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public string? Address { get; set; }
    public string? Phone { get; set; }

    public int ClassId { get; set; }
    public string? ClassName { get; set; }

    public string? ParentName { get; set; }
    public string? ParentPhone { get; set; }

    public string Status { get; set; } = "Active";
    public string StudentCode { get; set; } = string.Empty;

}