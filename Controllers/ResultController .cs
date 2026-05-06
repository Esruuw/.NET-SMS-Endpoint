using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/results")]
public class ResultController : ControllerBase
{
    private readonly IResultService _service;

    public ResultController(IResultService service)
    {
        _service = service;
    }

    [HttpGet("class/{classId}")]
    // public async Task<IActionResult> GetClassResult(int classId)
    // {
    //     var result = await _service.GetClassResultAsync(classId);
    //     return Ok(result);
    // }

    public async Task<ApiResponse<ClassResultDto>> GetClassResult(int classId)
    {
        try
        {
            var data = await _service.GetClassResultAsync(classId);

            return new ApiResponse<ClassResultDto>
            {
                IsSuccessful = true,
                Message = "",
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<ClassResultDto>
            {
                IsSuccessful = false,
                Message = ex.Message,
                Data = null
            };
        }
    }

    // [HttpGet("student/{studentId}")]
    // public async Task<IActionResult> GetStudentReport(int studentId)
    // {
    //     var result = await _service.GetStudentReportAsync(studentId);
    //     return Ok(result);
    // }
    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<ApiResponse<StudentReportDto>>> GetStudentReport(int studentId)
    {
        try
        {
            var data = await _service.GetStudentReportAsync(studentId);

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

// New endpoint for class statistics
[HttpGet("class/{classId}/stats")]
public async Task<ActionResult<ApiResponse<ClassStatisticsDto>>> GetClassStatistics(int classId)
{
    try
    {
        var data = await _service.GetClassStatisticsAsync(classId);

        return Ok(new ApiResponse<ClassStatisticsDto>
        {
            IsSuccessful = true,
            Data = data
        });
    }
    catch (Exception ex)
    {
        return NotFound(new ApiResponse<ClassStatisticsDto>
        {
            IsSuccessful = false,
            Message = ex.Message
        });
    }
}

}
