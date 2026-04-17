
namespace StudentApi.Models
{
    public class Class
    {
        public int ClassId { get; set; }

        public string ClassName { get; set; } = string.Empty; // Grade 1A
        public int GradeLevel { get; set; } // 1, 2, 3...

        public string? Section { get; set; } // A, B, C (optional)
        public string AcademicYear { get; set; } = string.Empty;

        // Foreign Key (Main Teacher)
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        // Navigation
        public ICollection<Student>? Students { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}
