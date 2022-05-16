using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    public interface IAsset
    {
        public string Ticker { get; }
        public string AssetType { get; }
        public double Amount { get; }
        public double AvgPrice { get; }
        public LinkedList<IOrder> OrdersList { get; }
        public LinkedList<ISellResult> SellResultsList { get; }

        public void Buy(IOrder order);
        public ISellResult Sell(IOrder order);
        public void Split(double split);
        public void ReverseSplit(double split);
    }
}
