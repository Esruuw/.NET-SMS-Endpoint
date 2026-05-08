using StudentApi.Dtos.Assessment;
using StudentApi.Models;
using StudentApi.Repositories.Interfaces;
using StudentApi.Services.Interfaces;

namespace StudentApi.Services.Implementations
{
    public class AssessmentService
        : IAssessmentService
    {
        private readonly IAssessmentRepository
            _repository;

        public AssessmentService(
            IAssessmentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(
            CreateAssessmentDto dto)
        {
            double totalScore =
                dto.MidExam +
                dto.FinalExam +
                dto.Assignment +
                dto.Participation +
                dto.Attendance;

            var assessment =
                new Assessment
                {
                    StudentId =
                        dto.StudentId,

                    CourseId =
                        dto.CourseId,

                    Semester =
                        dto.Semester,

                    AcademicYear =
                        dto.AcademicYear,

                    MidExam =
                        dto.MidExam,

                    FinalExam =
                        dto.FinalExam,

                    Assignment =
                        dto.Assignment,

                    Participation =
                        dto.Participation,

                    Attendance =
                        dto.Attendance,

                    TotalScore =
                        totalScore
                };

            await _repository
                .AddAsync(assessment);
        }

        public async Task<List<AssessmentDto>>
            GetAllAsync()
        {
            var assessments =
                await _repository.GetAllAsync();

            return assessments.Select(a =>
                new AssessmentDto
                {
                    AssessmentId =
                        a.AssessmentId,

                    StudentName =
                        a.Student!.FirstName +
                        " " +
                        a.Student.LastName,

                    CourseName =
                        a.Course!.CourseName,

                    Semester =
                        a.Semester,

                    AcademicYear =
                        a.AcademicYear,

                    MidExam =
                        a.MidExam,

                    FinalExam =
                        a.FinalExam,

                    Assignment =
                        a.Assignment,

                    Participation =
                        a.Participation,

                    Attendance =
                        a.Attendance,

                    TotalScore =
                        a.TotalScore
                }).ToList();
        }

        public async Task<List<AssessmentDto>>
            GetByStudentIdAsync(
                int studentId)
        {
            var assessments =
                await _repository
                    .GetByStudentIdAsync(
                        studentId);

            return assessments.Select(a =>
                new AssessmentDto
                {
                    AssessmentId =
                        a.AssessmentId,

                    StudentName =
                        a.Student!.FirstName +
                        " " +
                        a.Student.LastName,

                    CourseName =
                        a.Course!.CourseName,

                    Semester =
                        a.Semester,

                    AcademicYear =
                        a.AcademicYear,

                    MidExam =
                        a.MidExam,

                    FinalExam =
                        a.FinalExam,

                    Assignment =
                        a.Assignment,

                    Participation =
                        a.Participation,

                    Attendance =
                        a.Attendance,

                    TotalScore =
                        a.TotalScore
                }).ToList();
        }
    }
}