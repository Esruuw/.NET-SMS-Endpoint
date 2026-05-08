// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/[controller]")]
// public class GradeController : ControllerBase
// {
//     private readonly IGradeService _service;

//     public GradeController(IGradeService service)
//     {
//         _service = service;
//     }

//     // POST: api/grade
//     [HttpPost]
//     public async Task<IActionResult> AddGrade([FromBody] CreateGradeDto dto)
//     {
//         var result = await _service.AddGradeAsync(dto);
//         return Ok(result);
//     }

//     // GET: api/grade
//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//     {
//         var result = await _service.GetAllAsync();
//         return Ok(result);
//     }
// }
