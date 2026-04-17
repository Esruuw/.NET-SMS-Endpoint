namespace StudentApi.Models
{
    public class Course
    {
        public int CourseId { get; set; } // ✅ PRIMARY KEY

        public string CourseName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? GradeLevel { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}