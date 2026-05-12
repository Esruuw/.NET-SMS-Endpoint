using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

namespace StudentApi.Repositories.Implementations
{
    public class FeePaymentRepository: IFeePaymentRepository
    {
        private readonly AppDbContext _context;

        public FeePaymentRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FeePayment>>
            GetAllAsync()
        {
            return await _context.FeePayments
                .Include(p => p.Student)
                .Include(p => p.Fee)
                .ToListAsync();
        }

        public async Task<FeePayment?>
            GetByIdAsync(int id)
        {
            return await _context.FeePayments
                .Include(p => p.Student)
                .Include(p => p.Fee)
                .FirstOrDefaultAsync(
                    p => p.FeePaymentId == id);
        }

        public async Task<List<FeePayment>>
            GetByStudentIdAsync(int studentId)
        {
            return await _context.FeePayments
                .Include(p => p.Student)
                .Include(p => p.Fee)
                .Where(p =>
                    p.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<FeePayment>>
            GetByFeeIdAsync(int feeId)
        {
            return await _context.FeePayments
                .Include(p => p.Student)
                .Include(p => p.Fee)
                .Where(p => p.FeeId == feeId)
                .ToListAsync();
        }

        public async Task AddAsync(
            FeePayment payment)
        {
            await _context.FeePayments
                .AddAsync(payment);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(
            FeePayment payment)
        {
            _context.FeePayments.Update(payment);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var payment =
                await _context.FeePayments
                    .FirstOrDefaultAsync(
                        p => p.FeePaymentId == id);

            if (payment != null)
            {
                _context.FeePayments.Remove(payment);

                await _context.SaveChangesAsync();
            }
        }
    }
}