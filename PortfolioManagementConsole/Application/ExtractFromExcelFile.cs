using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application
{
    public abstract class ExtractFromExcelFile
    {
        private ExcelReader excelReader;
        private ExcelSheetReader sheetReader;

        public ExtractFromExcelFile(string excelFilePath, string excelSheetName)
        {
            this.excelReader = new ExcelReader(excelFilePath);
            this.excelReader.OpenExcelFile();
            this.sheetReader = new ExcelSheetReader(this.excelReader, excelSheetName);
        }

        protected ExcelSheetReader SheetReader { get => sheetReader; }

        public void CloseExcelFile()
        {
            this.excelReader.CloseExcelFile();
        }
    }
}
