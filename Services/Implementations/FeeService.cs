using StudentApi.Dtos.Fee;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class FeeService : IFeeService
    {
        private readonly IFeeRepository _repository;

        public FeeService(IFeeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(
            CreateFeeDto dto)
        {
            var fee = new Fee
            {
                FeeName = dto.FeeName,
                Amount = dto.Amount,
                Description = dto.Description,
                ClassId = dto.ClassId,
                Semester = dto.Semester,
                AcademicYear = dto.AcademicYear,
                DueDate = dto.DueDate
            };

            await _repository.AddAsync(fee);
        }

        public async Task<List<FeeDto>>
            GetAllAsync()
        {
            var fees = await _repository
                .GetAllAsync();

            return fees.Select(f => new FeeDto
            {
                FeeId = f.FeeId,
                FeeName = f.FeeName,
                Amount = f.Amount,
                Description = f.Description,
                ClassName = f.Class!.ClassName,
                Semester = f.Semester,
                AcademicYear = f.AcademicYear,
                DueDate = f.DueDate
            }).ToList();
        }

        public async Task<List<FeeDto>>
            GetByClassIdAsync(int classId)
        {
            var fees = await _repository
                .GetFeesByClassIdAsync(classId);

            return fees.Select(f => new FeeDto
            {
                FeeId = f.FeeId,
                FeeName = f.FeeName,
                Amount = f.Amount,
                Description = f.Description,
                ClassName = f.Class!.ClassName,
                Semester = f.Semester,
                AcademicYear = f.AcademicYear,
                DueDate = f.DueDate
            }).ToList();
        }
    }
}