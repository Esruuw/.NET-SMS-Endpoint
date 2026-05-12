using System.ComponentModel.DataAnnotations;

namespace StudentApi.Models
{
    public class FeePayment
    {
        public int FeePaymentId { get; set; }

        // Student
        [Required]
        public int StudentId { get; set; }

        public Student? Student { get; set; }

        // Fee
        [Required]
        public int FeeId { get; set; }

        public Fee? Fee { get; set; }

        // Payment
        [Required]
        public decimal AmountPaid { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }
            = DateTime.Now;

        // Payment Method
        [StringLength(50)]
        public string? PaymentMethod { get; set; }

        // Bank / Transaction Ref
        [StringLength(100)]
        public string? TransactionId { get; set; }

        // Receipt
        [StringLength(50)]
        public string ReceiptNumber { get; set; }
            = string.Empty;

        // Payment Status
        [Required]
        [StringLength(30)]
        public string Status { get; set; }
            = "Completed";

        // Notes
        [StringLength(500)]
        public string? Remarks { get; set; }

        // Audit
        public DateTime CreatedAt { get; set; }
            = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }
    }
}