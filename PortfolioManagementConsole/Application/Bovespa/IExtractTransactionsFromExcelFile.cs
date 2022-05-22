using PortfolioManagementConsole.Domain.Bovespa;
using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Bovespa
{
    public interface IExtractTransactionsFromExcelFile
    {
        public LinkedList<ITransaction> Transactions { get; }
        public void ReadTransactions();
    }
}