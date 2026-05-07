using Microsoft.AspNetCore.Mvc;
using StudentApi.Services.Interfaces;
using StudentApi.Services.Implementations;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly PdfService _pdfService;

  public StudentController(
    IStudentService studentService,
    PdfService pdfService)
{
    _studentService = studentService;
    _pdfService = pdfService;
}

    // GET ALL STUDENTS
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students =
            await _studentService.GetAllAsync();

        return Ok(students);
    }

    // GET STUDENT BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student =
            await _studentService.GetByIdAsync(id);

        if (student == null)
            return NotFound("Student not found");

        return Ok(student);
    }

    // CREATE STUDENT
    [HttpPost]
    public async Task<IActionResult> Create(
        CreateStudentDto dto)
    {
        await _studentService.CreateAsync(dto);

        return Ok("Student created successfully");
    }

    // UPDATE STUDENT
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateStudentDto dto)
    {
        await _studentService.UpdateAsync(id, dto);

        return Ok("Student updated successfully");
    }

    // DELETE STUDENT
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentService.DeleteAsync(id);

        return Ok("Student deleted successfully");
    }

    // SEARCH STUDENTS
    [HttpGet("search")]
    public async Task<IActionResult> Search(
        int? id,
        string? name,
        string? gender,
        int? classId)
    {
        var result =
            await _studentService.SearchAsync(
                id,
                name,
                gender,
                classId);

        return Ok(new
        {
            isSuccessful = true,
            message = "",
            data = result
        });
    }

    // EXPORT REGISTERED STUDENTS PDF
    [HttpGet("pdf")]
    public async Task<IActionResult> ExportStudentsPdf()
    {
        var students =
            await _studentService.GetAllAsync();

        var pdf =
            _pdfService.GenerateStudentsListPdf(students);

        return File(
            pdf,
            "application/pdf",
            "RegisteredStudents.pdf");
    }


// EXPORT STUDENT ID CARD PDF
[HttpGet("{id}/idcard/pdf")]
public async Task<IActionResult> ExportStudentIdCard(int id)
{
    var student = await _studentService.GetByIdAsync(id);

    if (student == null)
        return NotFound("Student not found");

    var pdf = _pdfService.GenerateStudentIdCardPdf(student);

    return File(
        pdf,
        "application/pdf",
        $"StudentIdCard_{student.StudentCode}.pdf");
}
}