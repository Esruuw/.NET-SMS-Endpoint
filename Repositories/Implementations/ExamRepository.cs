using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

public class ExamRepository : IExamRepository
{
    private readonly AppDbContext _context;

    public ExamRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Exam?> GetByIdAsync(int id)
    {
        return await _context.Exams
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.ExamId == id);
    }

    public async Task<List<Exam>> GetAllAsync()
    {
        return await _context.Exams
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task<List<Exam>> GetByClassIdAsync(int classId)
    {
        // Prefer direct ClassId on Exam if set, otherwise fall back to timetable lookup
        var direct = await _context.Exams
            .Include(e => e.Course)
            .Include(e => e.Class)
            .Where(e => e.ClassId == classId)
            .ToListAsync();

        if (direct.Any()) return direct;

        var exams = await (from e in _context.Exams
                           join t in _context.Timetables on e.CourseId equals t.CourseId
                           where t.ClassId == classId
                           select e)
                          .Include(e => e.Course)
                          .Include(e => e.Class)
                          .Distinct()
                          .ToListAsync();

        return exams;
    }

    public async Task AddAsync(Exam entity)
    {
        await _context.Exams.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Exam entity)
    {
        _context.Exams.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var e = await _context.Exams.FindAsync(id);
        if (e == null) return;
        _context.Exams.Remove(e);
        await _context.SaveChangesAsync();
    }
}
