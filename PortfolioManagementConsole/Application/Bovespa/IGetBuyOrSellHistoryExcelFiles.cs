using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Bovespa
{
    public interface IGetBuyOrSellHistoryExcelFiles
    {
        public LinkedList<string> ExcelFileNames { get; }
    }
}
