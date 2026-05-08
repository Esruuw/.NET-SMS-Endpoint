using ClosedXML.Excel;
using StudentApi.Models;

namespace StudentApi.Services.Implementations
{
    public class ExcelService : IExcelService
    {
        public byte[]
            GenerateStudentAttendanceExcel(
            List<AttendanceDto> attendances,
            int studentId)
        {
            using var workbook =
                new XLWorkbook();

            var worksheet =
                workbook.Worksheets
                    .Add("Attendance");

            worksheet.Cell(1, 1).Value =
                "Student Attendance Report";

            worksheet.Cell(3, 1).Value =
                "Student Name";

            worksheet.Cell(3, 2).Value =
                "Course";

            worksheet.Cell(3, 3).Value =
                "Date";

            worksheet.Cell(3, 4).Value =
                "Status";

            worksheet.Cell(3, 5).Value =
                "Remark";

            int row = 4;

            foreach (var item in attendances)
            {
                worksheet.Cell(row, 1).Value =
                    item.StudentName;

                worksheet.Cell(row, 2).Value =
                    item.CourseName;

                worksheet.Cell(row, 3).Value =
                    item.Date.ToShortDateString();

                worksheet.Cell(row, 4).Value =
                    item.Status;

                worksheet.Cell(row, 5).Value =
                    item.Remark;

                row++;
            }

            using var stream =
                new MemoryStream();

            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public byte[]
            GenerateClassAttendanceExcel(
            List<AttendanceDto> attendances,
            int classId)
        {
            using var workbook =
                new XLWorkbook();

            var worksheet =
                workbook.Worksheets
                    .Add("Class Attendance");

            worksheet.Cell(1, 1).Value =
                $"Class Attendance Report";

            worksheet.Cell(3, 1).Value =
                "Student Name";

            worksheet.Cell(3, 2).Value =
                "Course";

            worksheet.Cell(3, 3).Value =
                "Date";

            worksheet.Cell(3, 4).Value =
                "Status";

            worksheet.Cell(3, 5).Value =
                "Remark";

            int row = 4;

            foreach (var item in attendances)
            {
                worksheet.Cell(row, 1).Value =
                    item.StudentName;

                worksheet.Cell(row, 2).Value =
                    item.CourseName;

                worksheet.Cell(row, 3).Value =
                    item.Date.ToShortDateString();

                worksheet.Cell(row, 4).Value =
                    item.Status;

                worksheet.Cell(row, 5).Value =
                    item.Remark;

                row++;
            }

            using var stream =
                new MemoryStream();

            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}