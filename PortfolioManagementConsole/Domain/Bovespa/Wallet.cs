using PortfolioManagementConsole.Application.Bovespa;
using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    public class Wallet
    {

        private List<ITransaction> _transactions = new List<ITransaction>();
        private List<ITransactionDayCost> _transactionsDayCost = new List<ITransactionDayCost>();
        private readonly IGetBuyOrSellHistoryExcelFiles historyExcelFiles;
        private Dictionary<int,AnnualAssetReport> annualAssets;

        public Wallet(string notasCorretagemPath)
        {
            this.historyExcelFiles = new GetBuyOrSellHistoryExcelFiles(notasCorretagemPath);

            foreach (string filePath in this.historyExcelFiles.ExcelFileNames)
            {
                AddTransactionsFromExcelFile(filePath);
            }
            _transactions.Sort();
            _transactionsDayCost.Sort();
            this.annualAssets = new Dictionary<int,AnnualAssetReport>();
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

        public void ConsolidateAnnualAssetReport()
        {
            this.annualAssets = new Dictionary<int, AnnualAssetReport>();
            List<int> yearsTransactions = this._transactions.Select(y => y.Date.Year).Distinct().ToList();
            bool firstYear = true;

            for (int year = yearsTransactions.Min<int>(); year < yearsTransactions.Max<int>() + 1; year++)
            {
                if (firstYear)
                {
                    firstYear = false;
                    this.annualAssets[year] = new AnnualAssetReport(year);
                    this.annualAssets[year].ProcessTransactions(this.filterTransactionsByYear(year));
                }
                else
                {
                    this.annualAssets[year] = this.annualAssets[year - 1].CreateBaseForNextYearReport();
                    this.annualAssets[year].ProcessTransactions(this.filterTransactionsByYear(year));
                }
            }
        }

        private List<ITransaction> filterTransactionsByYear(int year)
        {
            return this._transactions.Where(t => t.Date.Year == year).ToList();
        }

        public void GenerateAnnualAssetStatements()
        {
            foreach (AnnualAssetReport assetReport in this.AnnualAssets.Values)
            {
                var generator = new GenerateAnnualAssetReportExcel(String.Format("{0} Asset Report.xlsx", assetReport.Year), assetReport);
                generator.GenerateReport();
            }
        }

        public List<ITransaction> Transactions => this._transactions;
        public List<ITransactionDayCost> TransactionsDayCosts => this._transactionsDayCost;
        public Dictionary<int, AnnualAssetReport> AnnualAssets => this.annualAssets;
    }
}
