using OfficeOpenXml;
using PortfolioManagementConsole.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application
{
    internal class ExcelFileGenerator
    {
        private string outputDir;
        private string fileName;
        private FileInfo fileInfo;

        public ExcelFileGenerator(string fileName)
        {
            this.outputDir = "D:/VisualStudioProjects/PortfolioManagementConsole/OutputData/";
            this.fileName = fileName;
            this.fileInfo = new FileInfo(this.outputDir + this.fileName);
        }

        public void ReplaceFileIfAlreadyExists()
        {
            if (this.fileInfo.Exists)
            {
                this.fileInfo.Delete();
            }
            this.fileInfo = new FileInfo(this.outputDir + this.fileName);
        }

        public void CreateSheetFromDict(IExcelSheetTable excelSheetTable, Dictionary<string, IReflectiveProperty> dict)
        {
            ExcelPackage excelPackage;

            using (excelPackage = new ExcelPackage(this.fileInfo))
            {
                excelSheetTable.GenerateSheetFromDictionary(excelPackage, dict);
                excelPackage.SaveAs(this.outputDir + this.fileName);
            }
        }

        public FileInfo FileInfo => fileInfo;
    }
}
