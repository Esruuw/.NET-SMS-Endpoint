using StudentApi.DTOs;
using StudentApi.Models;
using StudentApi.Service;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;
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

            double average = courses.Any()
                ? courses.Sum(c => c.Score) / courses.Count
                : 0;

            studentResults.Add(new StudentResultDto
            {
                StudentId = student.StudentId,
                StudentName = student.FirstName + " " + student.LastName,
                AverageScore = average,
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
}
