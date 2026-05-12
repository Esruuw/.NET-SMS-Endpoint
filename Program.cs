using StudentApi.Data;
using Microsoft.EntityFrameworkCore;
using StudentApi.Repositories.Interfaces;
using StudentApi.Repositories.Implementations;
using StudentApi.Services.Interfaces;
using StudentApi.Services.Implementations;
using QuestPDF.Infrastructure;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


// QUEST PDF LICENSE

QuestPDF.Settings.License = LicenseType.Community;


// DB CONTEXT
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// REPOSITORIES
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IClassRepository, ClassRepository>();

builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IGradeRepository, GradeRepository>();

builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<ITeachingAssignmentRepository, TeachingAssignmentRepository>();

builder.Services.AddScoped<IResultRepository, ResultRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ITimetableRepository, TimetableRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
builder.Services.AddScoped<IFeeRepository, FeeRepository>();
builder.Services.AddScoped<IFeePaymentRepository, FeePaymentRepository>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IPromotionService, PromotionService>();


// SERVICES
builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<IClassService, ClassService>();

builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<IGradeService, GradeService>();

builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddScoped<ITeachingAssignmentService, TeachingAssignmentService>();

builder.Services.AddScoped<IResultService, ResultService>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITimetableService, TimetableService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAssessmentService, AssessmentService>();
builder.Services.AddScoped<IFeeService, FeeService>();
builder.Services.AddScoped<IFeePaymentService, FeePaymentService>();
builder.Services.AddScoped<IExamService, ExamService>();



// PDF SERVICE
builder.Services.AddScoped<PdfService>();


//EXCEL SERVICE
builder.Services.AddScoped<IExcelService, ExcelService>();



// JWT AUTHENTICATION
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,

                ValidateAudience = true,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!
                        ))
            };
    });

// AUTHORIZATION
builder.Services.AddAuthorization();

// CONTROLLERS
builder.Services.AddControllers();

// SWAGGER
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// BUILD APP
var app = builder.Build();

// DEVELOPMENT
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

// MIDDLEWARE
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// MAP CONTROLLERS
app.MapControllers();

// RUN APP
app.Run();