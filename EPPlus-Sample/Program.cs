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

            if (System.IO.File.Exists("prueba.xlsx"))
            {
                System.IO.File.Delete("prueba.xlsx");
            }

            FileInfo prueba = new FileInfo("prueba.xlsx");

            using (ExcelPackage excel = new ExcelPackage(prueba))
            {

                AddTeachers(excel.Workbook);

                AddLectures(excel.Workbook);

                AddSummary(excel.Workbook);

                HighlightCells(excel.Workbook);

                AddConditionalFormatting(excel.Workbook);

                excel.Save();
            }



            FileInfo uploaded = new FileInfo("teachers.xlsx");

            using (ExcelPackage excel = new ExcelPackage(uploaded))
            {
                var teacherWorksheet = excel.Workbook.Worksheets.Single(ws => ws.Name == "Maestros");
                var cells = teacherWorksheet.Cells;
                int rowCount = cells["A:A"].Count();

                for (int i = 1; i <= rowCount; i++)
                {
                    Console.WriteLine(
                        cells["A" + i].Value.ToString() + "\t" +
                        cells["B" + i].Value.ToString() + "\t" +
                        cells["C" + i].Value.ToString() + "\t" +
                        cells["D" + i].Value.ToString() + "\t" 
                        );
                }


            }


            Console.Read();
        }

        private static void AddConditionalFormatting(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets.Single(ws => ws.Name == "Maestros");


            var lectureLevelCells = teacherWorksheet.Cells["E:E"].Skip(1);
            var ageCellsStringAddress = "$E$2:$E$31";
            var ageCellsAddress = new ExcelAddress(ageCellsStringAddress);

            var formatting = teacherWorksheet.ConditionalFormatting.AddTwoColorScale(ageCellsAddress);
            formatting.LowValue.Type = OfficeOpenXml.ConditionalFormatting.eExcelConditionalFormattingValueObjectType.Formula;
            formatting.HighValue.Type = OfficeOpenXml.ConditionalFormatting.eExcelConditionalFormattingValueObjectType.Formula;
            formatting.LowValue.Formula = "MIN(" + ageCellsAddress + ")";
            formatting.LowValue.Color = Color.LightGreen;

            formatting.HighValue.Formula = "MAX(" + ageCellsAddress + ")";
            formatting.HighValue.Color = Color.Green;
        }

        private static void AddSummary(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets.Add("Resumen");

            var titleCell = teacherWorksheet.Cells["A1:B1"];
            titleCell.Merge = true;
            titleCell.Style.Font.Bold = true;
            titleCell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            titleCell.Value = "Resumen";

            // Supported functions http://epplus.codeplex.com/wikipage?title=Supported%20Functions

            teacherWorksheet.Cells["A2:A4"].Style.Font.Bold = true;

            teacherWorksheet.Cells["A2"].Value = "Edad promedio";
            teacherWorksheet.Cells["B2"].Formula = "AVERAGE(Maestros!E2:E" + (Database.Teachers.Count() + 1) + ")";

            teacherWorksheet.Cells["A3"].Value = "Profesores sin email";
            teacherWorksheet.Cells["B3"].Formula = "COUNTIF(Maestros!D2:D" + (Database.Teachers.Count() + 1) + ",\"\")";
        }

        private static void HighlightCells(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets.Single(ws => ws.Name == "Maestros");

            var cellsWithYoungTeachers = from cell in teacherWorksheet.Cells["E:E"].Skip(1)
                                         where ((int)cell.Value) < 20
                                         select cell;

            foreach (var cell in cellsWithYoungTeachers)
            {
                cell.Style.Fill.PatternType = ExcelFillStyle.DarkDown;
                cell.Style.Fill.BackgroundColor.SetColor(Color.Indigo);
                cell.Style.Font.Color.SetColor(Color.Snow);
            }


            var lecturesWorksheet = wb.Worksheets
                .Single(ws => ws.Name == "Clases");

            var willamsTeachersCells = from cell in lecturesWorksheet.Cells["D:D"].Skip(1)
                                       where ((string)cell.Value) == "advanced"
                                       select cell;

            foreach (var cell in willamsTeachersCells)
            {
                cell.Style.Border.BorderAround(ExcelBorderStyle.MediumDashDot, Color.Blue);
            }
        }

        public static void AddTeachers(ExcelWorkbook wb)
        {
            var teacherWorksheet = wb.Worksheets.Add("Maestros");

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
            var worksheet = wb.Worksheets.Add("Clases");

            worksheet.Cells["A1"].Value = "ID";
            worksheet.Cells["B1"].Value = "Nombre";
            worksheet.Cells["C1"].Value = "ID Maestro";
            worksheet.Cells["D1"].Value = "Nivel";

            worksheet.Cells["A1:D1"].Style.Font.Bold = true;

            var query = from t in Database.Teachers
                        join c in Database.Lectures on t.Id equals c.TeacherId
                        select new { c.Id, c.Name, c.TeacherId, Teacher = t.GivenName + " " + t.LastName, c.Level };

            int cell = 2;
            foreach (var lectuire in query)
            {

                worksheet.Cells["A" + cell].Value = lectuire.Id;
                worksheet.Cells["B" + cell].Value = lectuire.Name;
                worksheet.Cells["C" + cell].Value = lectuire.TeacherId;
                worksheet.Cells["C" + cell].AddComment(lectuire.Teacher, "Antonio Feregrino");
                worksheet.Cells["D" + cell].Value = lectuire.Level;

                cell++;
            }
        }
    }
}
