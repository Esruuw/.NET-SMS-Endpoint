using StudentApi.Models;

namespace StudentApi.Repositories.Interfaces
{
    public interface IFeeRepository
    {
        // Get single fee
        Task<Fee?> GetByIdAsync(int id);

        // Get all fees
        Task<List<Fee>> GetAllAsync();

        // Get fees by class
        Task<List<Fee>>
            GetFeesByClassIdAsync(int classId);

        // Get fees by semester
        Task<List<Fee>>
            GetBySemesterAsync(string semester);

        // Get fees by academic year
        Task<List<Fee>>
            GetByAcademicYearAsync(
                string academicYear);

        // Create
        Task AddAsync(Fee fee);

        // Update
        Task UpdateAsync(Fee fee);

        // Delete
        Task DeleteAsync(int id);
    }
}