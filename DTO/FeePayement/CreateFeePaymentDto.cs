namespace StudentApi.Dtos.FeePayment
{
    public class CreateFeePaymentDto
    {
        public int StudentId { get; set; }

        public int FeeId { get; set; }

        public decimal AmountPaid { get; set; }

        public string? PaymentMethod { get; set; }

        public string? TransactionId { get; set; }

        public string? Remarks { get; set; }
    }
}