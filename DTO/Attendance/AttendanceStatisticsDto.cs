namespace StudentApi.Models
{
    public class AttendanceStatisticsDto
    {
        public int TotalDays { get; set; }

        public int Present { get; set; }

        public int Absent { get; set; }

        public int Late { get; set; }

        public double AttendancePercentage { get; set; }
    }
}