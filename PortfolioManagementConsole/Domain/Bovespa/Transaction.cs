using Newtonsoft.Json;
using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class Transaction : ITransaction, IComparable<ITransaction>
    {
        private readonly DateTime transactionDate;
        private readonly string ticker;
        private readonly string buyOrSell;
        private readonly int amount;
        private readonly double avgPrice;

        public Transaction(DateTime transactionDate, string ticker, string buyOrSell, int amount, double avgPrice)
        {
            this.transactionDate = transactionDate;
            this.ticker = ticker;
            this.buyOrSell = buyOrSell;
            this.amount = amount;
            this.avgPrice = avgPrice;

            if (this.buyOrSell == "V")
            {
                this.amount *= -1;
            }
        }

        public DateTime Date => this.transactionDate;

        public string Ticker => this.ticker;

        public string BuyOrSell => this.buyOrSell;

        public double Amount => this.amount;

        public double AvgPrice => this.avgPrice;

        public double TotalPrice => this.avgPrice*this.amount;

        public int CompareTo(ITransaction? other)
        {
            if (other is null) return 1;
            else
            {
                int transDateCompare = this.Date.CompareTo(other.Date);
                int transTickerCompare = this.Ticker.CompareTo(other.Ticker);
                int transBuyOrSell = this.BuyOrSell.CompareTo(other.BuyOrSell);

                if (transDateCompare == 0)
                {
                    if (transTickerCompare == 0)
                    {
                        if (transBuyOrSell == 0)
                        {
                            return 1;
                        }
                        else
                        {
                            return transBuyOrSell;
                        }
                    }
                    else
                    {
                        return transTickerCompare;
                    }
                }
                else
                {
                    return transDateCompare;
                }
            };
        }

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
