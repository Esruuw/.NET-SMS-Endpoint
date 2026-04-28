using Microsoft.AspNetCore.Mvc;
// using StudentApi.Service;
using StudentApi.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/student
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetAllAsync();
        return Ok(students);
    }

    // GET: api/student/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _studentService.GetByIdAsync(id);

        if (student == null)
            return NotFound("Student not found");

        return Ok(student);
    }

    // POST: api/student
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentDto dto)
    {
        await _studentService.CreateAsync(dto);
        return Ok("Student created successfully");
    }

    // PUT: api/student/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateStudentDto dto)
    {
        await _studentService.UpdateAsync(id, dto);
        return Ok("Student updated successfully");
    }

    // DELETE: api/student/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.DeleteAsync(id);
        return Ok("Student deleted successfully");
    }
}
