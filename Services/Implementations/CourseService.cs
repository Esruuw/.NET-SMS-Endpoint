using StudentApi.DTOs.Courses;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        // GET ALL

        public async Task<List<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAllAsync();

            return courses.Select(c => new CourseDto
            {
                SubjectId = c.CourseId,              // mapping
                SubjectName = c.CourseName,          // mapping
                Description = c.Description,
                GradeLevel = c.GradeLevel
            }).ToList();
        }

        // GET BY ID
        public async Task<CourseDto?> GetByIdAsync(int id)
        {
            var c = await _courseRepository.GetByIdAsync(id);

            if (c == null) return null;

            return new CourseDto
            {
                SubjectId = c.CourseId,
                SubjectName = c.CourseName,
                Description = c.Description,
                GradeLevel = c.GradeLevel
            };
        }

        // CREATE
        public async Task CreateAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                CourseName = dto.SubjectName,   // mapping
                Description = dto.Description,
                GradeLevel = dto.GradeLevel,
                CreatedAt = DateTime.Now
            };

            await _courseRepository.AddAsync(course);
        }

        // UPDATE
        public async Task UpdateAsync(int id, UpdateCourseDto dto)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null) return;

            course.CourseName = dto.SubjectName; // mapping
            course.Description = dto.Description;
            course.GradeLevel = dto.GradeLevel;
            course.UpdatedAt = DateTime.Now;

            await _courseRepository.UpdateAsync(course);
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }
    }
}