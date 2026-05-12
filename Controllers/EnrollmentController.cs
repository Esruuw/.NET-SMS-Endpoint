// using Microsoft.AspNetCore.Mvc;

// [ApiController]
// [Route("api/[controller]")]
// public class EnrollmentController : ControllerBase
// {
//     private readonly IEnrollmentService _service;

//     public EnrollmentController(IEnrollmentService service)
//     {
//         _service = service;
//     }

//     // POST: api/enrollment
//     [HttpPost]
//     public async Task<IActionResult> Enroll([FromBody] CreateEnrollmentDto dto)
//     {
//         var result = await _service.EnrollStudentAsync(dto);
//         return Ok(result);
//     }

//     // GET: api/enrollment
//     [HttpGet]
//     public async Task<IActionResult> GetAll()
//     {
//         var result = await _service.GetAllAsync();
//         return Ok(result);
//     }
// }
