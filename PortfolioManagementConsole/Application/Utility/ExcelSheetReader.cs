using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application
{
    public class ExcelSheetReader
    {
        private readonly string excelSheetName;
        private readonly ExcelWorksheet excelWorksheet;
        private int filledRows;
        private int filledColumns;

        public string ExcelSheetName => excelSheetName;
        public ExcelWorksheet ExcelWorksheet { get => excelWorksheet; }
        public int FilledRows { get => filledRows; }
        public int FilledColumns { get => filledColumns; }

        public ExcelSheetReader(ExcelReader excelReader, string excelSheetName)
        {
            this.excelSheetName = excelSheetName;
            this.excelWorksheet = excelReader.Package.Workbook.Worksheets[this.excelSheetName];
            this.CountAndSetFilledRows();
            this.CountAndSetFilledColumns();
        }

        private void CountAndSetFilledRows()
        {
            int line = 1, column = 1;
            var cellValue = this.excelWorksheet.Cells[line,column].Value;

            while (cellValue != null)
            {
                line++;
                cellValue = this.excelWorksheet.Cells[line, column].Value;
            }

            this.filledRows = line;
        }

        private void CountAndSetFilledColumns()
        {
            int line = 1, column = 1;
            var cellValue = this.excelWorksheet.Cells[line, column].Value;

            while (cellValue != null)
            {
                column++;
                cellValue = this.excelWorksheet.Cells[line, column].Value;
            }

            this.filledColumns = column;
        }
    }
}
