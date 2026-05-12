namespace StudentApi.Dtos.FeePayment
{
    public class FeePaymentDto
    {
        public int FeePaymentId { get; set; }

        public string StudentName { get; set; }
            = string.Empty;

        public string FeeName { get; set; }
            = string.Empty;

        public decimal AmountPaid { get; set; }

        public DateTime PaymentDate { get; set; }

        public string? PaymentMethod { get; set; }

        public string? TransactionId { get; set; }

        public string ReceiptNumber { get; set; }
            = string.Empty;

        public string Status { get; set; }
            = string.Empty;
    }
}