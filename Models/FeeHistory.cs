using System;

namespace StudentApi.Models
{
    public class FeeHistory
    {
        public int FeeHistoryId { get; set; }

        public int FeePaymentId { get; set; }

        public int StudentId { get; set; }

        public int FeeId { get; set; }

        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentMethod { get; set; }

        public string? TransactionId { get; set; }

        public string? ReceiptNumber { get; set; }

        public string? Status { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
