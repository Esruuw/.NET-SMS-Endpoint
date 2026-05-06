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
                CourseId = e.CourseId,
                CourseName = e.Course.CourseName,
                Score = e.Grade?.Score ?? 0
            }).ToList();

            // ✅ Calculate Total Score
            double totalScore = courses.Sum(c => c.Score);

            // ✅ Calculate Average
            double average = courses.Any()
                ? totalScore / courses.Count
                : 0;

            // ✅ PASS / FAIL LOGIC
            const int passMark = 50;
            bool isPassed = average >= passMark;
            string status = isPassed ? "Pass" : "Fail";

            studentResults.Add(new StudentResultDto
            {
                StudentId = student.StudentId,
                StudentName = student.FirstName + " " + student.LastName,
                TotalScore = totalScore,
                AverageScore = Math.Round(average, 2),
                TotalCourses = courses.Count,

                IsPassed = isPassed,
                Status = status,

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
            AcademicYear = classEntity.AcademicYear,
            Students = rankedStudents
        };
    }

    public async Task<StudentReportDto> GetStudentReportAsync(int studentId)
    {
        var student = await _repository.GetStudentWithClassAsync(studentId);

        if (student == null)
            throw new Exception("Student not found");

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

            IsPassed = currentStudent.IsPassed,
            Status = currentStudent.Status,

            Courses = currentStudent.Courses
        };
    }



// Class Statistics
// This method provides an overview of the class performance
// It calculates total students, pass/fail counts, pass rate, and identifies the top student
    public async Task<ClassStatisticsDto> GetClassStatisticsAsync(int classId)
{
    // reuse your existing logic
    var classResult = await GetClassResultAsync(classId);

    var students = classResult.Students;

    int totalStudents = students.Count;
    int passed = students.Count(s => s.IsPassed);
    int failed = totalStudents - passed;

    double passRate = totalStudents > 0
        ? (double)passed / totalStudents * 100
        : 0;

    var topStudent = students
        .OrderByDescending(s => s.AverageScore)
        .FirstOrDefault();

    return new ClassStatisticsDto
    {
        ClassId = classResult.ClassId,
        ClassName = classResult.ClassName,

        TotalStudents = totalStudents,
        Passed = passed,
        Failed = failed,
        PassRate = Math.Round(passRate, 2),

        TopStudent = topStudent?.StudentName ?? ""
    };
}
}