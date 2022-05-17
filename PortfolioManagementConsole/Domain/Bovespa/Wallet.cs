using PortfolioManagementConsole.Application.Bovespa;
using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class Wallet
    {

        private List<ITransaction> _transactions = new List<ITransaction>();
        private List<ITransactionDayCost> _transactionsDayCost = new List<ITransactionDayCost>();
        private readonly IGetBuyOrSellHistoryExcelFiles historyExcelFiles;

        public Wallet(string notasCorretagemPath)
        {
            this.historyExcelFiles = new GetBuyOrSellHistoryExcelFiles(notasCorretagemPath);

            foreach (string filePath in this.historyExcelFiles.ExcelFileNames)
            {
                AddTransactionsFromExcelFile(filePath);
            }
            _transactions.Sort();
            _transactionsDayCost.Sort();
        }

        private void AddTransactionsFromExcelFile(string fileName)
        {
            IExtractTransactionsFromExcelFile transactionsFromExcelFile = new ExtractTransactionsFromExcelFile(fileName);
            IExtractTransactionDayCostFromExcelFile transactionDayCostFromExcelFile = new ExtractTransactionDayCostFromExcelFile(fileName);

            transactionsFromExcelFile.ReadTransactions();
            transactionDayCostFromExcelFile.ReadTransactionsDayCosts();

            foreach (var newTransaction in transactionsFromExcelFile.Transactions)
            {
                this._transactions.Add(newTransaction);
            }

            foreach (var newTransactionDayCost in transactionDayCostFromExcelFile.TransactionDayCosts)
            {
                this._transactionsDayCost.Add(newTransactionDayCost);
            }
        }

        public List<ITransaction> Transactions => this._transactions;
        public List<ITransactionDayCost> TransactionsDayCosts => this._transactionsDayCost;
    }
}
