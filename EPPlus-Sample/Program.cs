using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPPlus_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDatabase database = new FakeDatabase();

            FileInfo prueba = new FileInfo("prueba.xlsx");

            using (ExcelPackage excel = new ExcelPackage(prueba))
            {

                var teacherWorksheet = excel.Workbook.Worksheets
                    .SingleOrDefault(ws => ws.Name == "Maestros") ??
                    excel.Workbook.Worksheets.Add("Maestros");

                teacherWorksheet.Cells["A1"].Value = "ID";
                teacherWorksheet.Cells["B1"].Value = "Nombre";
                teacherWorksheet.Cells["C1"].Value = "Apellidos";
                teacherWorksheet.Cells["D1"].Value = "Email";
                teacherWorksheet.Cells["E1"].Value = "Edad";

                teacherWorksheet.Cells["A1:E1"].Style.Font.Bold = true;

                int cell = 2;
                foreach (var teacher in database.Teachers)
                {

                    teacherWorksheet.Cells["A" + cell].Value = teacher.Id;
                    teacherWorksheet.Cells["B" + cell].Value = teacher.GivenName;
                    teacherWorksheet.Cells["C" + cell].Value = teacher.LastName;
                    teacherWorksheet.Cells["D" + cell].Value = teacher.Email;
                    teacherWorksheet.Cells["E" + cell].Value = teacher.Age;

                    cell++;
                }

                excel.Save();
            }



        }
    }
}
