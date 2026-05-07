using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.Class) // include class info
            .ToListAsync();
    }

    public async Task<Student?> GetByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.StudentId == id);
    }

    public async Task AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Student>> SearchAsync(
            int? id,
            string? name,
            string? gender,
            int? classId)
        {
            var query = _context.Students
                .Include(s => s.Class)
                .AsQueryable();

            // Filter by Id
            if (id.HasValue)
            {
                query = query.Where(s => s.StudentId == id.Value);
            }

            // Filter by Name
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(s =>
                    s.FirstName.Contains(name) ||
                    s.LastName.Contains(name));
            }

            // Filter by Gender
            if (!string.IsNullOrWhiteSpace(gender))
            {
                query = query.Where(s => s.Gender == gender);
            }

            // Filter by Class
            if (classId.HasValue)
            {
                query = query.Where(s => s.ClassId == classId.Value);
            }

            return await query.ToListAsync();
        }
    }
    
