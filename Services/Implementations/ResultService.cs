using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;
using StudentApi.Models;

public class ResultService : IResultService
{
    private readonly IResultRepository _repository;

    public ResultService(IResultRepository repository)
    {
        _repository = repository;
    }

    public async Task<ClassResultDto> GetClassResultAsync(int classId)
    {
        var classEntity = await _repository.GetClassWithStudentsAsync(classId);

        if (classEntity == null)
            throw new Exception("Class not found");

        var studentResults = new List<StudentResultDto>();

        foreach (var student in classEntity.Students)
        {
            var enrollments = await _repository.GetEnrollmentsByStudentIdAsync(student.StudentId);

            var courses = enrollments.Select(e => new CourseResultDto
            {
                CourseName = e.Course.CourseName,
                Score = e.Grade?.Score ?? 0
            }).ToList();

            // ✅ Calculate Total Score
            double totalScore = courses.Sum(c => c.Score);

            // ✅ Calculate Average
            double average = courses.Any()
                ? totalScore / courses.Count
                : 0;

            studentResults.Add(new StudentResultDto
            {
                StudentId = student.StudentId,
                StudentName = student.FirstName + " " + student.LastName,
                TotalScore = totalScore,                  //new
                AverageScore = Math.Round(average, 2),    // optional rounding
                Courses = courses
            });
        }


        // 🎯 Ranking
        var rankedStudents = studentResults
            .OrderByDescending(s => s.AverageScore)
            .Select((s, index) =>
            {
                s.Rank = index + 1;
                return s;
            })
            .ToList();

        return new ClassResultDto
        {
            ClassId = classEntity.ClassId,
            ClassName = classEntity.ClassName,
            Students = rankedStudents
        };
    }


    public async Task<StudentReportDto> GetStudentReportAsync(int studentId)
    {
        var student = await _repository.GetStudentWithClassAsync(studentId);

        if (student == null)
            throw new Exception("Student not found");

        // Get all students in the same class (for ranking)
        var classResult = await GetClassResultAsync(student.ClassId);

        var currentStudent = classResult.Students
            .FirstOrDefault(s => s.StudentId == studentId);

        if (currentStudent == null)
            throw new Exception("Student result not found");

        return new StudentReportDto
        {
            StudentId = student.StudentId,
            StudentName = student.FirstName + " " + student.LastName,
            ClassName = student.Class?.ClassName ?? "",

            TotalScore = currentStudent.TotalScore,
            AverageScore = currentStudent.AverageScore,
            Rank = currentStudent.Rank,

            Courses = currentStudent.Courses
        };
    }

}

