using StudentApi.DTOs;
using StudentApi.Models;
public interface IGradeService
{
    Task<GradeDto> AddGradeAsync(CreateGradeDto dto);
    Task<List<GradeDto>> GetAllAsync();
}
