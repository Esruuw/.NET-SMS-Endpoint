using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

namespace StudentApi.Repositories.Implementations
{
    public class TimetableRepository : ITimetableRepository
    {
        private readonly AppDbContext _context;

        public TimetableRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Timetable>> GetAllAsync()
        {
            return await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .ToListAsync();
        }

        public async Task<List<Timetable>> GetByClassIdAsync(int classId)
        {
            return await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .Where(t => t.ClassId == classId)
                .ToListAsync();
        }

        public async Task<List<Timetable>> GetByTeacherIdAsync(int teacherId)
        {
            return await _context.Timetables
                .Include(t => t.Class)
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .Where(t => t.TeacherId == teacherId)
                .ToListAsync();
        }

        public async Task AddAsync(Timetable timetable)
        {
            await _context.Timetables.AddAsync(timetable);

            await _context.SaveChangesAsync();
        }
    }
}