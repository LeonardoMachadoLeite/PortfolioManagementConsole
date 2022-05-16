using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    internal abstract class Asset : IAsset
    {
        private readonly string ticker;
        private readonly string assetType;
        private double amount;
        private double avgPrice;

        private LinkedList<IOrder> ordersList;
        private LinkedList<ISellResult> sellResultsList;

        public Asset(string ticker, string assetType)
        {
            this.ticker = ticker;
            this.assetType = assetType;
            this.amount = 0;
            this.avgPrice = 0;

            this.ordersList = new LinkedList<IOrder>();
            this.sellResultsList = new LinkedList<ISellResult>();
        }

        public void Buy(IOrder order)
        {
            Trace.Assert(order.Amount > 0);

            this.CalculateNewAvgPrice(order);
            this.amount += order.Amount;
        }

        private void CalculateNewAvgPrice(IOrder order)
        {
            this.avgPrice = (this.amount*this.avgPrice + order.Amount*order.AvgPrice) / (this.amount+order.Amount);
        }

        public ISellResult Sell(IOrder order)
        {
            Trace.Assert(order.Amount < 0);

            this.amount += order.Amount;
            double saleResult = this.CalculateSaleResult(order);
            return new SellResult(order, saleResult);
        }

        private double CalculateSaleResult(IOrder order)
        {
            return (this.avgPrice - order.AvgPrice) * order.Amount;
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
        public LinkedList<IOrder> OrdersList => ordersList;
        public LinkedList<ISellResult> SellResultsList => sellResultsList;
    }
}
