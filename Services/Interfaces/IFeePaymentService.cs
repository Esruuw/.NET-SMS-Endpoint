using StudentApi.Dtos.FeePayment;

namespace StudentApi.Services.Interfaces
{
    public interface IFeePaymentService
    {
        Task CreateAsync(CreateFeePaymentDto dto);

        Task<List<FeePaymentDto>>
            GetAllAsync();

        Task<List<FeePaymentDto>>
            GetByStudentIdAsync(int studentId);
    }
}