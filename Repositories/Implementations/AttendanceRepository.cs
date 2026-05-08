using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;

namespace StudentApi.Repositories.Implementations
{
    public class AttendanceRepository
        : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Attendance>>
            GetAllAsync()
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Timetable)
                    .ThenInclude(t => t!.Course)
                .ToListAsync();
        }

        public async Task AddAsync(
            Attendance attendance)
        {
            await _context.Attendances
                .AddAsync(attendance);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Attendance>>
            GetByStudentIdAsync(int studentId)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Timetable)
                    .ThenInclude(t => t!.Course)
                .Where(a => a.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<Attendance>>
            GetByClassIdAsync(int classId)
        {
            return await _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Timetable)
                    .ThenInclude(t => t!.Course)
                .Where(a =>
                    a.Timetable!.ClassId == classId)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(
            int studentId,
            int timetableId,
            DateTime date)
        {
            return await _context.Attendances
                .AnyAsync(a =>
                    a.StudentId == studentId &&
                    a.TimetableId == timetableId &&
                    a.Date.Date == date.Date);
        }
    }
}