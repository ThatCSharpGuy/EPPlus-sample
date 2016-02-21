using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Style;

namespace EPPlus_Sample
{
    class Program
    {
        static readonly FakeDatabase Database = new FakeDatabase();
        static void Main(string[] args)
        {

            FileInfo prueba = new FileInfo("prueba.xlsx");

            using (ExcelPackage excel = new ExcelPackage(prueba))
            {

                AddTeachers(excel.Workbook);

                AddLectures(excel.Workbook);

                AddSummary(excel.Workbook);

                HighlightYoungTeachers(excel.Workbook);

                excel.Save();
            }



        }

        private static void AddSummary(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets
                   .SingleOrDefault(ws => ws.Name == "Resumen") ??
                   wb.Worksheets.Add("Resumen");

            teacherWorksheet.Cells["A:A"].Style.Font.Bold = true;
        }

        private static void HighlightYoungTeachers(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets
                .Single(ws => ws.Name == "Maestros");

            var cellsWithYoungTeachers = from cell in teacherWorksheet.Cells["E:E"].Skip(1)
                                         where ((int)cell.Value) < 25
                                         select cell;

            foreach (var cell in cellsWithYoungTeachers)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.DarkGray;
                cell.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
            }
        }

        public static void AddTeachers(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets
                   .SingleOrDefault(ws => ws.Name == "Maestros") ??
                   wb.Worksheets.Add("Maestros");

            teacherWorksheet.Cells["A1"].Value = "ID";
            teacherWorksheet.Cells["B1"].Value = "Nombre";
            teacherWorksheet.Cells["C1"].Value = "Apellidos";
            teacherWorksheet.Cells["D1"].Value = "Email";
            teacherWorksheet.Cells["E1"].Value = "Edad";

            teacherWorksheet.Cells["A1:E1"].Style.Font.Bold = true;

            int cell = 2;
            foreach (var teacher in Database.Teachers)
            {

                teacherWorksheet.Cells["A" + cell].Value = teacher.Id;
                teacherWorksheet.Cells["B" + cell].Value = teacher.GivenName;
                teacherWorksheet.Cells["C" + cell].Value = teacher.LastName;
                teacherWorksheet.Cells["D" + cell].Value = teacher.Email;
                teacherWorksheet.Cells["E" + cell].Value = teacher.Age;

                cell++;
            }
        }


        public static void AddLectures(ExcelWorkbook wb)
        {
            var worksheet = wb.Worksheets
                   .SingleOrDefault(ws => ws.Name == "Clases") ??
                   wb.Worksheets.Add("Clases");

            worksheet.Cells["A1"].Value = "ID";
            worksheet.Cells["B1"].Value = "Nombre";
            worksheet.Cells["C1"].Value = "Maestro";
            worksheet.Cells["D1"].Value = "Nivel";

            worksheet.Cells["A1:D1"].Style.Font.Bold = true;

            var query = from t in Database.Teachers
                        join c in Database.Lectures on t.Id equals c.TeacherId
                        select new { c.Id, c.Name, Teacher = t.GivenName, c.Level };

            int cell = 2;
            foreach (var lectuire in query)
            {

                worksheet.Cells["A" + cell].Value = lectuire.Id;
                worksheet.Cells["B" + cell].Value = lectuire.Name;
                worksheet.Cells["C" + cell].Value = lectuire.Teacher;
                worksheet.Cells["D" + cell].Value = lectuire.Level;

                cell++;
            }
        }
    }
}
