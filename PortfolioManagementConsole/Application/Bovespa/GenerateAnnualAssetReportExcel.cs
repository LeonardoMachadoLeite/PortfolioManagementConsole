using OfficeOpenXml;
using PortfolioManagementConsole.Application.Utility;
using PortfolioManagementConsole.Domain.Bovespa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Bovespa
{
    internal class GenerateAnnualAssetReportExcel
    {
        private ExcelFileGenerator excelFileGenerator;
        private AnnualAssetReport annualAssetReport;

        public GenerateAnnualAssetReportExcel(string fileName, AnnualAssetReport annualAssetReport)
        {
            this.excelFileGenerator = new ExcelFileGenerator(fileName);
            this.annualAssetReport = annualAssetReport;
        }

        public void GenerateReport()
        {
            this.excelFileGenerator.ReplaceFileIfAlreadyExists();
            var sheet = this.annualAssetReport.CreateAnnualAssetReportSheetTable();
            this.excelFileGenerator.CreateSheetFromDict(sheet, this.annualAssetReport.GetAnnualAssetDetails());
        }
    }
}
