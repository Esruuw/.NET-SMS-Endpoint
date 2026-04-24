using Microsoft.EntityFrameworkCore;
using StudentApi.Data;


public class GradeRepository : IGradeRepository
{
    private readonly AppDbContext _context;

    public GradeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Grade?> GetByIdAsync(int id)
    {
        return await _context.Grades
            .Include(g => g.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(g => g.Enrollment)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(g => g.GradeId == id);
    }

    public async Task<List<Grade>> GetAllAsync()
    {
        return await _context.Grades
            .Include(g => g.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(g => g.Enrollment)
                .ThenInclude(e => e.Course)
            .ToListAsync();
    }

    public async Task AddAsync(Grade grade)
    {
        await _context.Grades.AddAsync(grade);
        await _context.SaveChangesAsync();
    }
}
