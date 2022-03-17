using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Model.Common
{
    internal abstract class Asset : IAsset
    {
        private readonly string ticker;
        private readonly string assetType;
        private double amount;
        private double avgPrice;

        public Asset(string ticker, string assetType)
        {
            this.ticker = ticker;
            this.assetType = assetType;
            this.amount = 0;
            this.avgPrice = 0;
        }

        public void Buy(BuyOrder order)
        {
            this.CalculateNewAvgPrice(order);
            this.amount += order.Amount;
        }

        private void CalculateNewAvgPrice(BuyOrder order)
        {
            this.avgPrice = (this.amount*this.avgPrice + order.Amount*order.AvgPrice) / (this.amount+order.Amount);
        }

        public SellResult Sell(SellOrder order)
        {
            this.amount -= order.Amount;
            double saleResult = this.CalculateSaleResult(order);
            return new SellResult(order, saleResult);
        }

        private double CalculateSaleResult(SellOrder order)
        {
            return (order.AvgPrice - this.avgPrice) * order.Amount;
        }

        public void Split(double split)
        {
            Trace.Assert(split > 1);

            this.amount *= split;
            this.avgPrice /= split;
        }

        public void ReverseSplit(double split)
        {
            Trace.Assert(split > 1);

            this.amount /= split;
            this.avgPrice *= split;
        }

        public string Ticker => this.ticker;
        public string AssetType => this.assetType;
        public double Amount => this.amount;
        public double AvgPrice => this.avgPrice;

    }
}
