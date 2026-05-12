using Microsoft.AspNetCore.Mvc;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _examService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _examService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult> GetByClassId(int classId)
        {
            var result = await _examService.GetByClassIdAsync(classId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto dto)
        {
            await _examService.CreateAsync(dto);
            return Ok("Exam created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateExamDto dto)
        {
            await _examService.UpdateAsync(id, dto);
            return Ok("Exam updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examService.DeleteAsync(id);
            return Ok("Exam deleted successfully");
        }
    }
}
