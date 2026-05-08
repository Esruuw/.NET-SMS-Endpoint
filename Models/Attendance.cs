namespace StudentApi.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }

        public int TimetableId { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } = string.Empty;
        // Present / Absent / Late

        public string? Remark { get; set; }

        public Student? Student { get; set; }

        public Timetable? Timetable { get; set; }
    }
}

