using Microsoft.AspNetCore.Mvc;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableService _service;

        public TimetableController(
            ITimetableService service)
        {
            _service = service;
        }

        // GET: api/timetable
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();

            return Ok(data);
        }

        // GET: api/timetable/class/3
        [HttpGet("class/{classId}")]
        public async Task<IActionResult>
            GetByClassId(int classId)
        {
            var data =
                await _service.GetByClassIdAsync(classId);

            return Ok(data);
        }

        // GET: api/timetable/teacher/2
        [HttpGet("teacher/{teacherId}")]
        public async Task<IActionResult>
            GetByTeacherId(int teacherId)
        {
            var data =
                await _service.GetByTeacherIdAsync(teacherId);

            return Ok(data);
        }

        // POST: api/timetable
        [HttpPost]
        public async Task<IActionResult>
            Create(CreateTimetableDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok("Timetable created successfully");
        }
    }
}