using Microsoft.AspNetCore.Mvc;
using StudentApi.Dtos.Fee;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeController : ControllerBase
    {
        private readonly IFeeService _service;

        public FeeController(
            IFeeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult>
            Create(CreateFeeDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                isSuccessful = true,
                message =
                    "Fee created successfully"
            });
        }

        [HttpGet]
        public async Task<IActionResult>
            GetAll()
        {
            var data =
                await _service.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult>
            GetByClass(int classId)
        {
            var data =
                await _service
                    .GetByClassIdAsync(
                        classId);

            return Ok(data);
        }
    }
}