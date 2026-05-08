using StudentApi.Dtos.Assessment;

namespace StudentApi.Services.Interfaces
{
    public interface IAssessmentService
    {
        Task CreateAsync(
            CreateAssessmentDto dto);

        Task<List<AssessmentDto>>
            GetAllAsync();

        Task<List<AssessmentDto>>
            GetByStudentIdAsync(int studentId);
    }
}