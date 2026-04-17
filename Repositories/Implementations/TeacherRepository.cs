using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

namespace StudentApi.Repositories.Implementations
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }


        // GET ALL

        public async Task<List<Teacher>> GetAllAsync()
        {
            return await _context.Teachers
                .Include(t => t.Classes) // optional: include related classes
                .ToListAsync();

            // return await _context.Teachers.ToListAsync();

        }


        // GET BY ID

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = await _context.Teachers
                .Include(t => t.Classes)
                .FirstOrDefaultAsync(t => t.TeacherId == id);

            if (teacher == null)
                throw new Exception("Teacher not found");

            return teacher;
        }


        // ADD

        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }


        // UPDATE

        public async Task UpdateAsync(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }


        // DELETE

        public async Task DeleteAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                throw new Exception("Teacher not found");

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}