using System;

namespace StudentApi.Models
{
    public class Exam
    {
        public int ExamId { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public int? ClassId { get; set; }
        public Class? Class { get; set; }

        public DateTime ExamDate { get; set; }

        // Duration in minutes
        public int DurationMinutes { get; set; }

        public double TotalMarks { get; set; }
        public string? Description { get; set; }
    }
}
