namespace StudentApi.Models
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }

        public string StudentName { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Remark { get; set; }
    }
}