using StudentApi.Models;

namespace StudentApi.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }

        // Student
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        // Course
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        // Semester Info
        public string Semester { get; set; }
            = string.Empty;

        public string AcademicYear { get; set; }
            = string.Empty;

        // Assessment Components
        public double MidExam { get; set; }

        public double FinalExam { get; set; }

        public double Assignment { get; set; }

        public double Participation { get; set; }

        public double Attendance { get; set; }

        // Auto Calculated
        public double TotalScore { get; set; }

        public DateTime CreatedAt { get; set; }
            = DateTime.Now;
    }
}