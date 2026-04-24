using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TeachingAssignmentController : ControllerBase
{
    private readonly ITeachingAssignmentService _service;

    public TeachingAssignmentController(ITeachingAssignmentService service)
    {
        _service = service;
    }

    // POST: api/teachingassignment
    [HttpPost]
    public async Task<IActionResult> Assign([FromBody] CreateTeachingAssignmentDto dto)
    {
        var result = await _service.AssignAsync(dto);
        return Ok(result);
    }

    // GET: api/teachingassignment
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }
}
