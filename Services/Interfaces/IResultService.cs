public interface IResultService
{
    Task<ClassResultDto> GetClassResultAsync(int classId);
    Task<StudentReportDto> GetStudentReportAsync(int studentId);
}

