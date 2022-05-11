using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    public interface ISellOrder
    {
        public DateTime Date { get; }
        public string Ticker { get; }
        public double Amount { get; }
        public double AvgPrice { get; }
    }
}
