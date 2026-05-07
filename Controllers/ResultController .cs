using Microsoft.AspNetCore.Mvc;
using QuestPDF.Infrastructure;
using StudentApi.Models;
using StudentApi.Services.Implementations;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/results")]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _service;
        private readonly PdfService _pdfService;

        // CONSTRUCTOR
        public ResultController(
            IResultService service,
            PdfService pdfService)
        {
            _service = service;
            _pdfService = pdfService;
        }

        // GET CLASS RESULT
        [HttpGet("class/{classId}")]
        public async Task<ActionResult<ApiResponse<ClassResultDto>>>
            GetClassResult(int classId)
        {
            try
            {
                var data =
                    await _service.GetClassResultAsync(classId);

                return Ok(new ApiResponse<ClassResultDto>
                {
                    IsSuccessful = true,
                    Message = "",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<ClassResultDto>
                {
                    IsSuccessful = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        // GET STUDENT REPORT
        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<ApiResponse<StudentReportDto>>>
            GetStudentReport(int studentId)
        {
            try
            {
                var data =
                    await _service.GetStudentReportAsync(studentId);

                return Ok(new ApiResponse<StudentReportDto>
                {
                    IsSuccessful = true,
                    Message = "",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<StudentReportDto>
                {
                    IsSuccessful = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        // GET CLASS STATISTICS
        [HttpGet("class/{classId}/stats")]
        public async Task<ActionResult<ApiResponse<ClassStatisticsDto>>>
            GetClassStatistics(int classId)
        {
            try
            {
                var data =
                    await _service.GetClassStatisticsAsync(classId);

                return Ok(new ApiResponse<ClassStatisticsDto>
                {
                    IsSuccessful = true,
                    Message = "",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<ClassStatisticsDto>
                {
                    IsSuccessful = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }

        // EXPORT STUDENT REPORT PDF
        [HttpGet("student/{studentId}/pdf")]
        public async Task<IActionResult>
            ExportStudentPdf(int studentId)
        {
            try
            {
                // GET STUDENT REPORT
                var report =
                    await _service.GetStudentReportAsync(studentId);

                // GENERATE PDF
                var pdfBytes =
                    _pdfService.GenerateStudentReportPdf(report);

                // RETURN PDF FILE
                return File(
                    pdfBytes,
                    "application/pdf",
                    $"StudentReport_{studentId}.pdf");
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>
                {
                    IsSuccessful = false,
                    Message = ex.Message,
                    Data = null
                });
            }
        }
    }
}