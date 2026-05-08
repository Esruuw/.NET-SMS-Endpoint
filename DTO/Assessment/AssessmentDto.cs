namespace StudentApi.Dtos.Assessment
{
    public class AssessmentDto
    {
        public int AssessmentId { get; set; }

        public string StudentName { get; set; }
            = string.Empty;

        public string CourseName { get; set; }
            = string.Empty;

        public string Semester { get; set; }
            = string.Empty;

        public string AcademicYear { get; set; }
            = string.Empty;

        public double MidExam { get; set; }

        public double FinalExam { get; set; }

        public double Assignment { get; set; }

        public double Participation { get; set; }

        public double Attendance { get; set; }

        public double TotalScore { get; set; }
    }
}