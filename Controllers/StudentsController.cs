using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;
using StudentApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAll()
        {
            var students = await _service.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var student = await _service.GetStudentById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Add(Student student)
        {
            await _service.AddStudent(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student updatedStudent)
        {
            var existing = await _service.GetStudentById(id);
            if (existing == null) return NotFound();

            existing.Name = updatedStudent.Name;
            existing.Email = updatedStudent.Email;
            existing.Department = updatedStudent.Department;
            existing.Phone = updatedStudent.Phone;

            await _service.UpdateStudent(existing);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetStudentById(id);
            if (existing == null) return NotFound();

            await _service.DeleteStudent(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<Student>>> Search([FromQuery] int? id, [FromQuery] string? name,
                                                              [FromQuery] string? department, [FromQuery] string? phone)
        {
            var students = await _service.SearchStudent(id, name, department, phone);
            return Ok(students);
        }
    }
}
