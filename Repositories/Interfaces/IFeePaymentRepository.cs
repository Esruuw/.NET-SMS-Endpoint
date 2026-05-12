using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IFeePaymentRepository
    {
        Task<List<FeePayment>> GetAllAsync();

        Task<FeePayment?> GetByIdAsync(int id);

        Task<List<FeePayment>>
            GetByStudentIdAsync(int studentId);

        Task<List<FeePayment>>
            GetByFeeIdAsync(int feeId);

        Task AddAsync(FeePayment payment);

        Task UpdateAsync(FeePayment payment);

        Task DeleteAsync(int id);
    }
}