using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Model.Common
{
    internal interface IAsset
    {
        public string Ticker { get; }
        public string AssetType { get; }
        public double Amount { get; }
        public double AvgPrice { get; }

        public void Buy(BuyOrder order);
        public SellResult Sell(SellOrder order);
        public void Split(double split);
        public void ReverseSplit(double split);
    }
}
