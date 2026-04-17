using Microsoft.AspNetCore.Mvc;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }


        // GET ALL TEACHERS

        [HttpGet]
        public async Task<ActionResult<List<TeacherDto>>> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }


        // GET TEACHER BY ID

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);

            if (teacher == null)
                return NotFound("Teacher not found");

            return Ok(teacher);
        }

        // CREATE TEACHER

        [HttpPost]
        public async Task<ActionResult> Create(CreateTeacherDto dto)
        {
            await _teacherService.CreateAsync(dto);

            return Ok("Teacher created successfully");
        }


        // UPDATE TEACHER

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTeacherDto dto)
        {
            await _teacherService.UpdateAsync(id, dto);

            return Ok("Teacher updated successfully");
        }

        // DELETE TEACHER

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _teacherService.DeleteAsync(id);

            return Ok("Teacher deleted successfully");
        }
    }
}