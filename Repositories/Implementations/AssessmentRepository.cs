using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

namespace StudentApi.Repositories.Implementations
{
    public class AssessmentRepository
        : IAssessmentRepository
    {
        private readonly AppDbContext _context;

        public AssessmentRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(
            Assessment assessment)
        {
            await _context.Assessments
                .AddAsync(assessment);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Assessment>>
            GetAllAsync()
        {
            return await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Course)
                .ToListAsync();
        }

        public async Task<List<Assessment>>
            GetByStudentIdAsync(int studentId)
        {
            return await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Course)
                .Where(a =>
                    a.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<Assessment>>
            GetByCourseIdAsync(int courseId)
        {
            return await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Course)
                .Where(a =>
                    a.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Assessment?>
            GetByIdAsync(int id)
        {
            return await _context.Assessments
                .Include(a => a.Student)
                .Include(a => a.Course)
                .FirstOrDefaultAsync(a =>
                    a.AssessmentId == id);
        }
    }
}