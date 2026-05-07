namespace StudentApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string StudentCode { get; set; } = string.Empty;

        // Foreign Key
        public int ClassId { get; set; }
        public Class? Class { get; set; }

        // Simple parent info (you can normalize later)
        public string? ParentName { get; set; }
        public string? ParentPhone { get; set; }

        //public DateTime AdmissionDate { get; set; } = DateTime.Now;

        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }
}

