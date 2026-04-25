using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;


public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly AppDbContext _context;

    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Enrollment?> GetByIdAsync(int id)
    {
        return await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.EnrollmentId == id);
    }

    public async Task<List<Enrollment>> GetAllAsync()
    {
        return await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(int studentId, int courseId)
    {
        return await _context.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
    }

    public async Task AddAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
        await _context.SaveChangesAsync();
    }
}
