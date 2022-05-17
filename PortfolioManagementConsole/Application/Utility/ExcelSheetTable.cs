using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Utility
{
    public class ExcelSheetTable : IExcelSheetTable
    {
        private string sheetName;
        private LinkedList<string> tableHeaders;

        public ExcelSheetTable(string sheetName, LinkedList<string> tableHeaders)
        {
            this.sheetName = sheetName;
            this.tableHeaders = tableHeaders;
        }

        public void GenerateSheetFromDictionary(ExcelPackage package, Dictionary<string, IReflectiveProperty> dict)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(this.sheetName);
            int column = 1;
            int row = 2;
            
            foreach (string columnHeader in this.tableHeaders)
            {
                worksheet.Cells[1, column].Value = columnHeader;
                column++;
            }

            foreach (KeyValuePair<string, IReflectiveProperty> pair in dict)
            {
                column = 1;

                worksheet.Cells[row, column].Value = pair.Key;

                foreach (string columnHeader in this.tableHeaders)
                {
                    if (column != 1)
                    {
                        worksheet.Cells[row, column].Value = pair.Value.GetProperty(columnHeader);
                    }
                    
                    column++;
                }
                row++;
            }

        }
    }
}
