using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    public interface ISellResult
    {
        public DateTime Date { get; }

        public string Ticker { get; }

        public double AmountSold { get; }

        public double AvgPriceSale { get; }

        public double TotalValueSale { get; }

        public double TotalResult { get; }
    }
}
