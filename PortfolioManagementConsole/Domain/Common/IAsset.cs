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

        public void Buy(IBuyOrder order);
        public ISellResult Sell(ISellOrder order);
        public void Split(double split);
        public void ReverseSplit(double split);
    }
}
