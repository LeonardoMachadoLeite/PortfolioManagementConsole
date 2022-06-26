using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Common
{
    internal class MonthTransactions
    {
        private readonly int month;
        private readonly int year;

        private readonly LinkedList<ITransaction> ordersList;
        private readonly LinkedList<ISellResult> sellResultsList;

        public MonthTransactions(int month, int year)
        {
            this.month = month;
            this.year = year;

            this.ordersList = new LinkedList<ITransaction>();
            this.sellResultsList = new LinkedList<ISellResult>();
        }

        public int Month { get => month; }
        public int Year { get => year; }
        public List<ITransaction> OrdersList { get => ordersList.ToList(); }
        public List<ISellResult> SellResultsList { get => sellResultsList.ToList(); }
    }
}
