using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Utility
{
    public interface IExcelSheetTable
    {
        public void GenerateSheetFromDictionary(ExcelPackage package, Dictionary<string, IReflectiveProperty> dict);
    }
}
