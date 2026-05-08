using Microsoft.AspNetCore.Mvc;
using StudentApi.Dtos.Assessment;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentController
        : ControllerBase
    {
        private readonly IAssessmentService
            _service;

        public AssessmentController(
            IAssessmentService service)
        {
            _service = service;
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult>
            Create(CreateAssessmentDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                isSuccessful = true,
                message =
                    "Assessment created successfully"
            });
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult>
            GetAll()
        {
            var data =
                await _service.GetAllAsync();

            return Ok(new
            {
                isSuccessful = true,
                message = "",
                data = data
            });
        }

        // GET BY STUDENT
        [HttpGet("student/{studentId}")]
        public async Task<IActionResult>
            GetByStudent(int studentId)
        {
            var data =
                await _service
                    .GetByStudentIdAsync(
                        studentId);

            return Ok(new
            {
                isSuccessful = true,
                message = "",
                data = data
            });
        }
    }
}