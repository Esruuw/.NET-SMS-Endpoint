using StudentApi.Models;

public interface IExcelService
{
    byte[] GenerateStudentAttendanceExcel(
        List<AttendanceDto> attendances,
        int studentId);

    byte[] GenerateClassAttendanceExcel(
        List<AttendanceDto> attendances,
        int classId);
}