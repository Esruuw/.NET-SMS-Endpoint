using StudentApi.DTOs;
using StudentApi.Models;
public interface IEnrollmentService
{
    Task<EnrollmentDto> EnrollStudentAsync(CreateEnrollmentDto dto);
    Task<List<EnrollmentDto>> GetAllAsync();
}
