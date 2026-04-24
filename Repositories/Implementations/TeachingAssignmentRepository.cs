
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
public class TeachingAssignmentRepository : ITeachingAssignmentRepository
{
    private readonly AppDbContext _context;

    public TeachingAssignmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(int teacherId, int courseId)
    {
        return await _context.TeachingAssignments
            .AnyAsync(x => x.TeacherId == teacherId && x.CourseId == courseId);
    }

    public async Task<List<TeachingAssignment>> GetAllAsync()
    {
        return await _context.TeachingAssignments
            .Include(x => x.Teacher)
            .Include(x => x.Course)
            .ToListAsync();
    }

    public async Task AddAsync(TeachingAssignment entity)
    {
        await _context.TeachingAssignments.AddAsync(entity);
        await _context.SaveChangesAsync();
    }
}
