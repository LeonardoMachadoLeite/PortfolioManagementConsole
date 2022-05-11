using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application
{
    public class ExcelReader
    {
        private readonly string excelFilePath;
        private FileInfo excelFile;
        private ExcelPackage package;

        public ExcelPackage Package { get => package; }

        public ExcelReader(string excelFilePath)
        {
            this.excelFilePath = excelFilePath;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void OpenExcelFile()
        {
            this.SetExcelFile();
            this.package = new ExcelPackage(this.excelFile);
        }

        private void SetExcelFile()
        {
            this.excelFile = new FileInfo(excelFilePath);
            this.CheckIfExcelFileExists();
        }

        private void CheckIfExcelFileExists()
        {
            if (!this.excelFile.Exists)
            {
                throw new FileNotFoundException("Excel Workbook not found.", this.excelFilePath);
            }
        }

        public void CloseExcelFile()
        {
            this.package.Dispose();
        }
        
    }
}
