using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController
        : ControllerBase
    {
        // This controller handles attendance-related endpoints, allowing clients to mark attendance, retrieve attendance records by student or class, and get attendance statistics for a student.
        private readonly IAttendanceService _service;

        // Excel service for potential future use in exporting attendance data
        private readonly IExcelService _excelService;
        public AttendanceController(
            IAttendanceService service,
            IExcelService excelService)
        {
            _service = service;
            _excelService = excelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _service.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult>
            Create(CreateAttendanceDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(
                "Attendance marked successfully");
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult>
            GetByStudent(int studentId)
        {
            var result =
                await _service
                    .GetByStudentIdAsync(studentId);

            return Ok(result);
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult>
            GetByClass(int classId)
        {
            var result =
                await _service
                    .GetByClassIdAsync(classId);

            return Ok(result);
        }

        [HttpGet(
            "student/{studentId}/statistics")]
        public async Task<IActionResult>
            GetStatistics(int studentId)
        {
            var result =
                await _service
                    .GetStatisticsAsync(studentId);

            return Ok(result);
        }


        [HttpGet("student/{studentId}/excel")]
         public async Task<IActionResult>
         ExportStudentExcel(int studentId)
        {
        var attendances =
        await _service
            .GetByStudentIdAsync(studentId);

         var excel =
        _excelService
            .GenerateStudentAttendanceExcel(
                attendances,
                studentId);

    return File(
        excel,
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        $"StudentAttendance_{studentId}.xlsx");
}


[HttpGet("class/{classId}/excel")]
public async Task<IActionResult>
    ExportClassExcel(int classId)
{
    var attendances =
        await _service
            .GetByClassIdAsync(classId);

    var excel =
        _excelService
            .GenerateClassAttendanceExcel(
                attendances,
                classId);

    return File(
        excel,
        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        $"ClassAttendance_{classId}.xlsx");
}

    }
 
}