using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;

        public ClassService(IClassRepository classRepository)
        {
            _classRepository = classRepository;
        }

        public async Task<List<ClassDto>> GetAllAsync()
        {
            var classes = await _classRepository.GetAllAsync();

            return classes.Select(c => new ClassDto
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                GradeLevel = c.GradeLevel,
                Section = c.Section,
                AcademicYear = c.AcademicYear,
                TeacherId = c.TeacherId,
                // StudentCount = c.Students?.Count ?? 0
            }).ToList();
        }

        public async Task<ClassDto?> GetByIdAsync(int id)
        {
            var c = await _classRepository.GetByIdAsync(id);

            if (c == null) return null;

            return new ClassDto
            {
                ClassId = c.ClassId,
                ClassName = c.ClassName,
                GradeLevel = c.GradeLevel,
                Section = c.Section,
                AcademicYear = c.AcademicYear,
                TeacherId = c.TeacherId,
                // StudentCount = c.Students?.Count ?? 0
            };
        }

        public async Task CreateAsync(CreateClassDto dto)
        {
            var entity = new Class
            {
                ClassName = dto.ClassName,
                GradeLevel = dto.GradeLevel,
                Section = dto.Section,
                AcademicYear = dto.AcademicYear,
                TeacherId = dto.TeacherId
            };

            await _classRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(int id, UpdateClassDto dto)
        {
            var entity = await _classRepository.GetByIdAsync(id);
            if (entity == null) return;

            entity.ClassName = dto.ClassName;
            entity.GradeLevel = dto.GradeLevel;
            entity.Section = dto.Section;
            entity.AcademicYear = dto.AcademicYear;
            entity.TeacherId = dto.TeacherId;

            await _classRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _classRepository.DeleteAsync(id);
        }
    }
}