using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;

namespace Multicriteria
{
    class Excel
    {
        /// <summary>
        /// Read data from Excel File
        /// </summary>
        public static bool ReadXls(string filePath)
        {
            //FIXIT rm
            //filePath = "data.xlsx";
            Data.models = new List<Model>();
            Data.criteria = new List<Criterion>();
            Model.ResetModel();
            Criterion.ResetCriterion();
            // Get the file we are going to process
            var existingFile = new FileInfo(filePath);
            // Open and read the Xlsx file.
            // TODO: catch if ile is already opened
            using (var package = new ExcelPackage(existingFile))
            {
                // Get the work book in the file
                ExcelWorkbook workBook = package.Workbook;
                if (workBook != null)
                {
                    // TODO: Check data
                    if (workBook.Worksheets.Count > 0)
                    {
                        ExcelWorksheet dataWorksheet = workBook.Worksheets[1];
                        ExcelWorksheet sysWorksheet = workBook.Worksheets[2];
                        int modelsCount = CellToInt(sysWorksheet.Cells[1, 2]);
                        int criteriaCount = int.Parse(sysWorksheet.Cells[1, 4].Value.ToString());
                        Data.table = new double[modelsCount][];
                        for (int x = 0; x < modelsCount; x++) 
                        {
                            Data.table[x] = new double[criteriaCount];
                        }
                        for (int row = 0; row < modelsCount; row++)
                        {
                            for (int col = 0; col < criteriaCount; col++)
                            {
                                Data.table[row][col] = CellToFloat(dataWorksheet.Cells[row + 2, col + 2]);
                            }
                        }
                        for (int col = 1; col <= criteriaCount; col++)
                        {
                            Data.criteria.Add(new Criterion(dataWorksheet.Cells[1, col + 1].Value.ToString(), CellToInt(sysWorksheet.Cells[3, col])));
                        }
                        for (int row = 1; row <= modelsCount; row++)
                        {
                            Data.models.Add(new Model(dataWorksheet.Cells[row + 1, 1].Value.ToString()));
                        }
                    }
                }
                return true;
            }
        }


        private static double CellToFloat(ExcelRange cell)
        {
            try
            {
                string q = cell.Value.ToString().Replace(",", ".");
                return Convert.ToDouble(cell.Value.ToString().Replace(".",","));
            }
            catch
            {
                return 0;
            }
        }

        private static int CellToInt(ExcelRange cell)
        {
            try
            {
                return int.Parse(cell.Value.ToString());
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Generates the report.
        /// </summary>
        public static void GenerateReport(List<Criterion> criteria, List<Model> models)
        {
            using (ExcelPackage package = new ExcelPackage())
            {

                //set the workbook properties and add a default sheet in it
                SetWorkbookProperties(package);

                //Create a sheet
                ExcelWorksheet dataWorksheet = CreateSheet(package, "Сравнительные характеристики");
                ExcelWorksheet sysWorksheet = CreateSheet(package, "System");

                int rowIndex = 2;
                int colIndex = 1;

                FillModels(dataWorksheet, models, rowIndex, colIndex);

                rowIndex--;
                colIndex++;

                FillCriteria(dataWorksheet, criteria, rowIndex, colIndex);

                FillSysData(sysWorksheet, models, criteria);


                //Generate A File with Random name
                Byte[] bin = package.GetAsByteArray();
                string fileName = "data" + ".xlsx";
                File.WriteAllBytes(fileName, bin);

                //These lines will open it in Excel
                ProcessStartInfo pi = new ProcessStartInfo(fileName);
                Process.Start(pi);
            }
        }

        private static void FillCriteria(ExcelWorksheet ws, List<Criterion> criteria, int row, int col)
        {
            foreach (Criterion criterion in criteria)
            {
                var cellName = ws.Cells[row, col];
                //var cellValue = ws.Cells[row + 1, col];

                //Setting Value in cell
                cellName.Value = criterion.name;
                //cellValue.Value = criterion.value;
                col++;
            }
        }

        private static void FillModels(ExcelWorksheet ws, List<Model> models, int row, int col)
        {
            foreach (Model model in models)
            {
                var cell = ws.Cells[row, col];
                cell.Value = model.name;
                row++;
            }
        }

        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[p.Workbook.Worksheets.Count];
            ws.Name = sheetName; //Setting Sheet's name
            ws.Cells.Style.Font.Size = 11; //Default font size for whole sheet
            ws.Cells.Style.Font.Name = "Calibri"; //Default Font name for whole sheet

            return ws;
        }

        /// <summary>
        /// Sets the workbook properties and adds a default sheet.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private static void SetWorkbookProperties(ExcelPackage p)
        {
            //Here setting some document properties
            p.Workbook.Properties.Author = "Khazov Andrey";
            p.Workbook.Properties.Title = "Comparation table";


        }


        private static void FillSysData(ExcelWorksheet ws, List<Model> models, List<Criterion> criteria)
        {
            ws.Cells[1, 1].Value = "Models count";
            ws.Cells[1, 2].Value = models.Count;
            ws.Cells[1, 3].Value = "Criteria count";
            ws.Cells[1, 4].Value = criteria.Count;
            int col = 1;
            foreach (Criterion criterion in criteria)
            {
                ws.Cells[2, col].Value = criterion.name;
                ws.Cells[3, col].Value = criterion.value;
                col++;
            }
        }

        public static void WriteElectre(double[,] C, double[,] D, List<Model> models)
        {
            using (ExcelPackage package = new ExcelPackage())
            {

                SetWorkbookProperties(package);

                ExcelWorksheet agree = CreateSheet(package, "Согласие");
                ExcelWorksheet disagree = CreateSheet(package, "Несогласие");

                int current = 2;
                foreach (Model model in models)
                {
                    agree.Cells[1, current].Value = model.name;
                    agree.Cells[current, 1].Value = model.name;
                    disagree.Cells[1, current].Value = model.name;
                    disagree.Cells[current, 1].Value = model.name;
                    current++;
                }
                int modelsCount = models.Count;
                for (int r = 2; r <= modelsCount+1; ++r)
                    for (int c = 2; c <= modelsCount+1; ++c)
                    {
                        if (r == c)
                        {
                            agree.Cells[r, c].Value = "*";
                            disagree.Cells[r, c].Value = "*";
                        }
                        else
                        {
                            agree.Cells[r, c].Value = C[r-2, c-2];
                            disagree.Cells[r, c].Value = D[r - 2, c - 2];
                        }
                    }

                Byte[] bin = package.GetAsByteArray();
                string fileName = "ELECTRE_result" + ".xlsx";
                File.WriteAllBytes(fileName, bin);
                ProcessStartInfo pi = new ProcessStartInfo(fileName);
                Process.Start(pi);
            }
        }
    }
}
