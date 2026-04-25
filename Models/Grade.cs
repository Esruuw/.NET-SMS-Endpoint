using StudentApi.Models;

namespace StudentApi.Models
{
    public class Grade
    {
        public int GradeId { get; set; }

        public int EnrollmentId { get; set; }
        public Enrollment? Enrollment { get; set; }

        public double Score { get; set; }

        public string? Remark { get; set; }
    }
}
