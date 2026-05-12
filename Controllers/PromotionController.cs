using Microsoft.AspNetCore.Mvc;
using StudentApi.Services.Interfaces;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        [HttpPost("class/{classId}")]
        public async Task<IActionResult> PromoteClass(int classId, [FromQuery] string? targetAcademicYear = null, [FromQuery] int? performedByUserId = null)
        {
            await _promotionService.PromoteClassAsync(classId, targetAcademicYear, performedByUserId);
            return Ok("Class promoted successfully");
        }

        [HttpPost("grade/{fromGradeLevel}")]
        public async Task<IActionResult> PromoteGrade(int fromGradeLevel, [FromQuery] string? targetAcademicYear = null, [FromQuery] string? section = null, [FromQuery] int? performedByUserId = null)
        {
            await _promotionService.PromoteGradeAsync(fromGradeLevel, null, section, targetAcademicYear, performedByUserId);
            return Ok("Grade promoted successfully");
        }

        [HttpPost("student/{studentId}")]
        public async Task<IActionResult> PromoteStudent(int studentId, [FromQuery] int? targetClassId = null, [FromQuery] string? targetAcademicYear = null, [FromQuery] int? performedByUserId = null)
        {
            await _promotionService.PromoteStudentAsync(studentId, targetClassId, targetAcademicYear, performedByUserId);
            return Ok("Student promoted successfully");
        }
    }
}
