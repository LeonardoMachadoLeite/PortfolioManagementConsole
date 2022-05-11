using PortfolioManagementConsole.Domain.Bovespa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Bovespa
{
    public interface IExtractTransactionDayCostFromExcelFile
    {
        public LinkedList<ITransactionDayCost> TransactionDayCosts { get; }
        public void ReadTransactionsDayCosts();
    }
}
