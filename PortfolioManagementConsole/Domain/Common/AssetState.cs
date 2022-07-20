using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    public class AssetState : IAssetState
    {
        private readonly DateTime _date;
        private readonly string ticker;
        private readonly string assetType;
        private readonly double amount;
        private readonly double avgPrice;
        private double currentPrice;

        public AssetState(DateTime _date, string ticker, string assetType, double amount, double avgPrice)
        {
            this._date = _date;
            this.ticker = ticker;
            this.assetType = assetType;
            this.amount = amount;
            this.avgPrice = avgPrice;
        }

        public AssetState(DateTime _date, string ticker, string assetType, double amount, double avgPrice, double currentPrice) : this(_date, ticker, assetType, amount, avgPrice)
        {
            this.currentPrice = currentPrice;
        }

        public DateTime Date => this._date;
        public string Ticker => this.ticker;
        public string AssetType => this.assetType;
        public double Amount => this.amount;
        public double AvgPrice => this.avgPrice;
        public double CurrentPrice { get => this.currentPrice; set => this.currentPrice = value; }
    }
}
