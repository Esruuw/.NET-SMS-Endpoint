namespace StudentApi.Dtos.Assessment
{
    public class CreateAssessmentDto
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public string Semester { get; set; }
            = string.Empty;

        public string AcademicYear { get; set; }
            = string.Empty;

        public double MidExam { get; set; }

        public double FinalExam { get; set; }

        public double Assignment { get; set; }

        public double Participation { get; set; }

        public double Attendance { get; set; }
    }
}