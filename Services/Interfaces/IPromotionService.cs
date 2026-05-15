namespace StudentApi.Services.Interfaces
{
    public interface IPromotionService
    {
        Task PromoteClassAsync(int classId, string? targetAcademicYear = null, int? performedByUserId = null);
        Task PromoteGradeAsync(int fromGradeLevel, int? toGradeLevel = null, string? section = null, string? targetAcademicYear = null, int? performedByUserId = null);
        Task PromoteStudentAsync(int studentId, int? targetClassId = null, string? targetAcademicYear = null, int? performedByUserId = null);
        Task<List<EligibleStudentDto>> GetEligibleStudentsAsync(PromotionQueryDto dto);
    }
}
