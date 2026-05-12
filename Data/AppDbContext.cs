using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignments { get; set; }
        public DbSet<Timetable> Timetables { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<PromotionHistory> PromotionHistories { get; set; }

        public DbSet<FeePayment>
        FeePayments
        { get; set; }
        protected override void OnModelCreating(
        ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Timetable)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.TimetableId)
                .OnDelete(DeleteBehavior.NoAction);

            // FeePayment → Student
            modelBuilder.Entity<FeePayment>()
                .HasOne(fp => fp.Student)
                .WithMany()
                .HasForeignKey(fp => fp.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            // FeePayment → Fee
            modelBuilder.Entity<FeePayment>()
                .HasOne(fp => fp.Fee)
                .WithMany(f => f.FeePayments)
                .HasForeignKey(fp => fp.FeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}