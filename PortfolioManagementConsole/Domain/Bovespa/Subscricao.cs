using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class Subscricao
    {
        private readonly int idt;
        private readonly string name;
        private readonly string ticker;
        private readonly double priceAquisition;

        public Subscricao(int idt, string name, string ticker, double priceAquisition)
        {
            this.idt = idt;
            this.name = name;
            this.ticker = ticker;
            this.priceAquisition = priceAquisition;
        }

        public int Idt => idt;

        public string Name => name;

        public string Ticker => ticker;

        public double PriceAquisition => priceAquisition;
    }
}
