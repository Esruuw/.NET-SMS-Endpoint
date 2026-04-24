using StudentApi.DTOs;
using StudentApi.Models;
public interface ITeachingAssignmentService
{
    Task<TeachingAssignmentDto> AssignAsync(CreateTeachingAssignmentDto dto);
    Task<List<TeachingAssignmentDto>> GetAllAsync();
}
