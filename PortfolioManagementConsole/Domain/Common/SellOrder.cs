using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    internal class SellOrder : ISellOrder
    {
        private readonly DateTime date;
        private readonly string ticker;
        private readonly double amount;
        private readonly double avgPrice;

        public SellOrder(DateTime date, string ticker, double amount, double avgPrice)
        {
            Trace.Assert(amount > 0);

            this.ticker = ticker;
            this.amount = amount;
            this.avgPrice = avgPrice;
            this.date = date;
        }

        public DateTime Date => date;
        public string Ticker => ticker;
        public double Amount => amount;
        public double AvgPrice => avgPrice;

    }
}
