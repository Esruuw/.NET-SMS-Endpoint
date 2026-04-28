using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;

public class ResultRepository : IResultRepository
{
    private readonly AppDbContext _context;
    public ResultRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Class> GetClassWithStudentsAsync(int classId)
    {
        return await _context.Classes
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.ClassId == classId);
    }

    public async Task<List<Enrollment>> GetEnrollmentsByStudentIdAsync(int studentId)
    {
        return await _context.Enrollments
            .Include(e => e.Course)
            .Include(e => e.Grade)
            .Where(e => e.StudentId == studentId)
            .ToListAsync();
    }

    public async Task<Student?> GetStudentWithClassAsync(int studentId)
    {
        return await _context.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.StudentId == studentId);
    }

}
