namespace StudentApi.Models
{
    public class CreateAttendanceDto
    {
        public int StudentId { get; set; }

        public int TimetableId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } = string.Empty;

        public string? Remark { get; set; }
    }
}