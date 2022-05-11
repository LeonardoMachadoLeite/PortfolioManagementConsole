using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    public interface ITransaction
    {
        public DateTime TransactionDate { get; }

        public string Ticker { get; }

        public string BuyOrSell { get; }

        public int Amount { get; }

        public double AvgPrice { get; }

        public double TotalPrice { get; }

        public string GetJson();
    }
}
