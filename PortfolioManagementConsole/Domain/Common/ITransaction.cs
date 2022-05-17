using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    public interface ITransaction : IComparable<ITransaction>, IOrder
    {
        public string BuyOrSell { get; }
        public double TotalPrice { get; }
        public string GetJson();
    }
}
