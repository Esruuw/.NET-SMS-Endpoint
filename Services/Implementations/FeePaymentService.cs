using StudentApi.Dtos.FeePayment;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class FeePaymentService
        : IFeePaymentService
    {
        private readonly IFeePaymentRepository
            _paymentRepository;

        private readonly IFeeRepository
            _feeRepository;

        public FeePaymentService(
            IFeePaymentRepository paymentRepository,
            IFeeRepository feeRepository)
        {
            _paymentRepository = paymentRepository;
            _feeRepository = feeRepository;
        }

        public async Task CreateAsync(
            CreateFeePaymentDto dto)
        {
            var fee =
                await _feeRepository
                    .GetByIdAsync(dto.FeeId);

            if (fee == null)
                throw new Exception(
                    "Fee not found");

            var existingPayments =
                await _paymentRepository
                    .GetByStudentIdAsync(
                        dto.StudentId);

            decimal totalPaid =
                existingPayments
                    .Where(p => p.FeeId == dto.FeeId)
                    .Sum(p => p.AmountPaid);

            if (totalPaid + dto.AmountPaid
                > fee.Amount)
            {
                throw new Exception(
                    "Payment exceeds fee amount");
            }

            string receiptNumber =
                $"REC-{DateTime.Now.Year}-{Guid.NewGuid().ToString().Substring(0, 6)}";

            var payment = new FeePayment
            {
                StudentId = dto.StudentId,
                FeeId = dto.FeeId,
                AmountPaid = dto.AmountPaid,
                PaymentMethod = dto.PaymentMethod,
                TransactionId = dto.TransactionId,
                Remarks = dto.Remarks,
                ReceiptNumber = receiptNumber,
                Status = "Completed"
            };

            await _paymentRepository
                .AddAsync(payment);
        }

        public async Task<List<FeePaymentDto>>
            GetAllAsync()
        {
            var payments =
                await _paymentRepository
                    .GetAllAsync();

            return payments.Select(p =>
                new FeePaymentDto
                {
                    FeePaymentId =
                        p.FeePaymentId,

                    StudentName =
                        p.Student!.FirstName +
                        " " +
                        p.Student.LastName,

                    FeeName =
                        p.Fee!.FeeName,

                    AmountPaid =
                        p.AmountPaid,

                    PaymentDate =
                        p.PaymentDate,

                    PaymentMethod =
                        p.PaymentMethod,

                    TransactionId =
                        p.TransactionId,

                    ReceiptNumber =
                        p.ReceiptNumber,

                    Status =
                        p.Status
                }).ToList();
        }

        public async Task<List<FeePaymentDto>>
            GetByStudentIdAsync(
                int studentId)
        {
            var payments =
                await _paymentRepository
                    .GetByStudentIdAsync(
                        studentId);

            return payments.Select(p =>
                new FeePaymentDto
                {
                    FeePaymentId =
                        p.FeePaymentId,

                    StudentName =
                        p.Student!.FirstName +
                        " " +
                        p.Student.LastName,

                    FeeName =
                        p.Fee!.FeeName,

                    AmountPaid =
                        p.AmountPaid,

                    PaymentDate =
                        p.PaymentDate,

                    PaymentMethod =
                        p.PaymentMethod,

                    TransactionId =
                        p.TransactionId,

                    ReceiptNumber =
                        p.ReceiptNumber,

                    Status =
                        p.Status
                }).ToList();
        }
    }
}