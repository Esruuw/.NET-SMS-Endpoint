namespace StudentApi.Dtos.Fee
{
    public class CreateFeeDto
    {
        public string FeeName { get; set; }
            = string.Empty;

        public decimal Amount { get; set; }

        public string? Description { get; set; }

        public int ClassId { get; set; }

        public string Semester { get; set; }
            = string.Empty;

        public string AcademicYear { get; set; }
            = string.Empty;

        public DateTime DueDate { get; set; }
    }
}