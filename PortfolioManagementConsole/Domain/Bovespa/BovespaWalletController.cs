using PortfolioManagementConsole.Application.Bovespa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class BovespaWalletController
    {

        private LinkedList<ITransaction> _transactions = new LinkedList<ITransaction>();
        private LinkedList<ITransactionDayCost> _transactionsDayCost = new LinkedList<ITransactionDayCost>();
        private readonly IGetBuyOrSellHistoryExcelFiles historyExcelFiles;

        public BovespaWalletController(string notasCorretagemPath)
        {
            this.historyExcelFiles = new GetBuyOrSellHistoryExcelFiles(notasCorretagemPath);

            foreach (string filePath in this.historyExcelFiles.ExcelFileNames)
            {
                AddTransactionsFromExcelFile(filePath);
            }
        }

        private void AddTransactionsFromExcelFile(string fileName)
        {
            IExtractTransactionsFromExcelFile transactionsFromExcelFile = new ExtractTransactionsFromExcelFile(fileName);
            IExtractTransactionDayCostFromExcelFile transactionDayCostFromExcelFile = new ExtractTransactionDayCostFromExcelFile(fileName);

            transactionsFromExcelFile.ReadTransactions();
            transactionDayCostFromExcelFile.ReadTransactionsDayCosts();

            foreach (var newTransaction in transactionsFromExcelFile.Transactions)
            {
                this._transactions.AddLast(newTransaction);
            }

            foreach (var newTransactionDayCost in transactionDayCostFromExcelFile.TransactionDayCosts)
            {
                this._transactionsDayCost.AddLast(newTransactionDayCost);
            }
        }

        public LinkedList<ITransaction> Transactions => this._transactions;
        public LinkedList<ITransactionDayCost> TransactionsDayCosts => this._transactionsDayCost;
    }
}
