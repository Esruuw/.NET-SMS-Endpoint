namespace StudentApi.Dtos.Fee
{
    public class FeeDto
    {
        public int FeeId { get; set; }

        public string FeeName { get; set; }
            = string.Empty;

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public string ClassName { get; set; }
            = string.Empty;

        public string Semester { get; set; }
            = string.Empty;

        public string AcademicYear { get; set; }
            = string.Empty;

        public DateTime DueDate { get; set; }
    }
}