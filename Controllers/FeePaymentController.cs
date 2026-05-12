using Microsoft.AspNetCore.Mvc;
using StudentApi.Dtos.FeePayment;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeePaymentController
        : ControllerBase
    {
        private readonly IFeePaymentService
            _service;

        public FeePaymentController(
            IFeePaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult>
            Create(
                CreateFeePaymentDto dto)
        {
            await _service.CreateAsync(dto);

            return Ok(new
            {
                isSuccessful = true,
                message =
                    "Payment successful"
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

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult>
            GetByStudent(int studentId)
        {
            var data =
                await _service
                    .GetByStudentIdAsync(
                        studentId);

            return Ok(data);
        }
    }
}