using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    public interface ITransaction : IComparable<ITransaction>
    {
        public DateTime TransactionDate { get; }
        public string Ticker { get; }
        public string BuyOrSell { get; }
        public int Amount { get; }
        public double AvgPrice { get; }
        public double TotalPrice { get; }

        public IOrder ToBuyOrder();
        public IOrder ToSellOrder();
        public string GetJson();
    }
}
