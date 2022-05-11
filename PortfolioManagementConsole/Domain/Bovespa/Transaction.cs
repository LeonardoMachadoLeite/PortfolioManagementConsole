using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class Transaction : ITransaction
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
        }

        public DateTime TransactionDate => this.transactionDate;

        public string Ticker => this.ticker;

        public string BuyOrSell => this.buyOrSell;

        public int Amount => this.amount;

        public double AvgPrice => this.avgPrice;

        public double TotalPrice => this.avgPrice*this.amount;

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
