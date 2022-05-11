using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    internal class SellResult : ISellResult
    {
        private readonly DateTime date;
        private readonly string ticker;
        private readonly double amountSold;
        private readonly double avgPriceSale;
        private readonly double totalValueSale;
        private readonly double totalResult;

        public SellResult(DateTime date, string ticker, double amountSold, double avgPriceSale, double totalValueSale, double totalResult)
        {
            this.date = date;
            this.ticker = ticker;
            this.amountSold = amountSold;
            this.avgPriceSale = avgPriceSale;
            this.totalValueSale = totalValueSale;
            this.totalResult = totalResult;
        }
        public SellResult(ISellOrder order, double result)
        {
            this.date = order.Date;
            this.ticker = order.Ticker;
            this.amountSold = order.Amount;
            this.avgPriceSale = order.AvgPrice;
            this.totalValueSale = order.Amount*order.AvgPrice;
            this.totalResult = result;
        }

        public DateTime Date => date;

        public string Ticker => ticker;

        public double AmountSold => amountSold;

        public double AvgPriceSale => avgPriceSale;

        public double TotalValueSale => totalValueSale;

        public double TotalResult => totalResult;
    }
}
