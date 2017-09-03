using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace ExportToExcel
{
    public class Launcher
    {
        public static void Main()
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("OOP results");
            int usedColumnsCount = 0; // used later for setting the total width of the used cells

            using (StreamReader reader = new StreamReader("../../StudentData.txt"))
            {
                string line = reader.ReadLine();
                int startRow = 3; // the first and the second row will be merged for the heading
                int currentRow = startRow;

                while (line != null)
                {
                    string[] columns = line.Split('\t');
                    usedColumnsCount = columns.Length;

                    for (int i = 1; i <= columns.Length; i++)
                    {
                        sheet.Cells[currentRow, i].Value = columns[i - 1];
                    }

                    currentRow++;

                    line = reader.ReadLine();
                }

                // setting the font of the data rows:
                sheet.Cells[startRow, 1, currentRow, usedColumnsCount].Style.Font.Name = "Arial";
                sheet.Cells[startRow, 1, currentRow, usedColumnsCount].Style.Font.Size = 12;
            }

            // the first and the second rows are being merged for the heading:
            var headingRows = sheet.Cells[1, 1, 2, usedColumnsCount];
            headingRows.Merge = true;
            headingRows.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            headingRows.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            var headingFont = headingRows.Style.Font;
            headingFont.Bold = true;
            headingFont.Name = "Arial";
            headingFont.Size = 16;
            headingRows.Value = "Softuni OOP course results";

            // the row with the names of the columns (e.g. "First name", "Phone number")
            var columnsNamesRow = sheet.Cells[3, 1, 3, usedColumnsCount];
            columnsNamesRow.Style.Fill.PatternType = ExcelFillStyle.Solid;
            columnsNamesRow.Style.Fill.BackgroundColor.SetColor(Color.DarkGreen);
            var columnsNamesRowFont = columnsNamesRow.Style.Font;
            columnsNamesRowFont.Name = "Arial";
            columnsNamesRowFont.Size = 12;
            columnsNamesRowFont.Bold = true;
            columnsNamesRowFont.Color.SetColor(Color.White);

            // making all cells to autofit the content
            sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

            // creating the file
            var outputStream = new FileStream("../../results.xlsx", FileMode.Create);

            package.SaveAs(outputStream);
        }
    }
}
