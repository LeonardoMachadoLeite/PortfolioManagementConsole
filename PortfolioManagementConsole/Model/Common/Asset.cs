using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Model.Common
{
    internal abstract class Asset
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

        public void buy(BuyOrder order)
        {
            this.calculateNewAvgPrice(order);
            this.amount += order.Amount;
        }

        private void calculateNewAvgPrice(BuyOrder order)
        {
            this.avgPrice = (this.amount*this.avgPrice + order.Amount*order.AvgPrice) / (this.amount+order.Amount);
        }

        public SellResult sell(SellOrder order)
        {
            this.amount -= order.Amount;
            double saleResult = this.calculateSaleResult(order);
            return new SellResult(order, saleResult);
        }

        private double calculateSaleResult(SellOrder order)
        {
            return (order.AvgPrice - this.avgPrice) * order.Amount;
        }

        public void split(double split)
        {
            Trace.Assert(split > 1);

            this.amount *= split;
            this.avgPrice /= split;
        }

        public void reverseSplit(double split)
        {
            Trace.Assert(split > 1);

            this.amount /= split;
            this.avgPrice *= split;
        }

        public string Ticker => this.ticker;
        public string AssetType => assetType;
        public double Amount => this.amount;
        public double AvgPrice => this.avgPrice;

    }
}
