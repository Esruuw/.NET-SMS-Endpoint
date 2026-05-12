using StudentApi.Dtos.Fee;

namespace StudentApi.Services.Interfaces
{
    public interface IFeeService
    {
        Task CreateAsync(CreateFeeDto dto);

        Task<List<FeeDto>> GetAllAsync();

        Task<List<FeeDto>>
            GetByClassIdAsync(int classId);
    }
}