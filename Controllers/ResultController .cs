using Microsoft.AspNetCore.Mvc;
using StudentApi.Service;
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
    public async Task<IActionResult> GetClassResult(int classId)
    {
        var result = await _service.GetClassResultAsync(classId);
        return Ok(result);
    }
}
