using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

namespace StudentApi.Repositories.Implementations
{
    public class FeeRepository : IFeeRepository
    {
        private readonly AppDbContext _context;

        public FeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Fee?> GetByIdAsync(int id)
        {
            return await _context.Fees
                .Include(f => f.Class)
                .FirstOrDefaultAsync(f => f.FeeId == id);
        }

        public async Task<List<Fee>> GetAllAsync()
        {
            return await _context.Fees
                .Include(f => f.Class)
                .ToListAsync();
        }

        public async Task<List<Fee>>
            GetFeesByClassIdAsync(int classId)
        {
            return await _context.Fees
                .Include(f => f.Class)
                .Where(f => f.ClassId == classId)
                .ToListAsync();
        }

        // NEW
        public async Task<List<Fee>>
            GetBySemesterAsync(string semester)
        {
            return await _context.Fees
                .Include(f => f.Class)
                .Where(f => f.Semester == semester)
                .ToListAsync();
        }

        // NEW
        public async Task<List<Fee>>
            GetByAcademicYearAsync(
                string academicYear)
        {
            return await _context.Fees
                .Include(f => f.Class)
                .Where(f =>
                    f.AcademicYear == academicYear)
                .ToListAsync();
        }

        public async Task AddAsync(Fee fee)
        {
            await _context.Fees.AddAsync(fee);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fee fee)
        {
            _context.Fees.Update(fee);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fee = await _context.Fees
                .FirstOrDefaultAsync(
                    f => f.FeeId == id);

            if (fee != null)
            {
                _context.Fees.Remove(fee);

                await _context.SaveChangesAsync();
            }
        }
    }
}