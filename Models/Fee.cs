using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class Fee
    {
        public int FeeId { get; set; }

        [Required]
        [StringLength(100)]
        public string FeeName { get; set; }
            = string.Empty;

        [Required]
        public decimal Amount { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        // Class
        [Required]
        public int ClassId { get; set; }

        public Class? Class { get; set; }

        // Academic Info
        [Required]
        [StringLength(50)]
        public string Semester { get; set; }
            = string.Empty;

        [Required]
        [StringLength(20)]
        public string AcademicYear { get; set; }
            = string.Empty;

        // Payment Deadline
        [Required]
        public DateTime DueDate { get; set; }

        // Status
        public bool IsActive { get; set; }
            = true;

        // Audit
        public DateTime CreatedAt { get; set; }
            = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        // Navigation
        public ICollection<FeePayment>
            FeePayments { get; set; }
                = new List<FeePayment>();
    }
}