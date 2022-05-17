using OfficeOpenXml;
using PortfolioManagementConsole.Application.Utility;
using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class AnnualAssetReport
    {
        private int year;
        private Dictionary<string, IAsset> assetsEndOfPreviousYear;
        private Dictionary<string, IAsset> assetsEndOfYear;

        public AnnualAssetReport(int year)
        {
            this.year = year;
            this.assetsEndOfPreviousYear = new Dictionary<string, IAsset>();
            this.assetsEndOfYear = new Dictionary<string, IAsset>();
        }

        private AnnualAssetReport(int year, Dictionary<string, IAsset> listaAtivosAnoAnterior)
        {
            this.year = year;
            this.assetsEndOfPreviousYear = new Dictionary<string, IAsset>(listaAtivosAnoAnterior);
            this.assetsEndOfYear = new Dictionary<string, IAsset>();
        }

        public void ProcessTransactions(List<ITransaction> transactions)
        {
            var filteredTransactions = transactions.Where(t => t.Date.Year <= this.year);

            foreach (ITransaction transaction in filteredTransactions)
            {
                if (transaction.Date.Year < this.year)
                {
                    this.ProcessTransaction(this.assetsEndOfPreviousYear, transaction);
                }
                this.ProcessTransaction(this.assetsEndOfYear, transaction);
            }
        }

        private void ProcessTransaction(Dictionary<string, IAsset> assets, ITransaction transaction)
        {
            if (assets.ContainsKey(transaction.Ticker))
            {
                if (transaction.Amount > 0)
                {
                    assets[transaction.Ticker].Buy(transaction);
                }
                else
                {
                    assets[transaction.Ticker].Sell(transaction);
                }
                
            }
            else
            {
                assets[transaction.Ticker] = new Acao(transaction.Ticker);
            }
        }

        public AnnualAssetReport CreateBaseForNextYearReport()
        {
            return new AnnualAssetReport(year+1, this.assetsEndOfYear);
        }

        public IExcelSheetTable CreateAnnualAssetReportSheetTable()
        {
            return new ExcelSheetTable(Convert.ToString(this.year), AnnualAssetDetail.GetHeaders());
        }

        public int Year => year;
        public Dictionary<string, IAsset> AssetsEndOfPreviousYear => this.assetsEndOfPreviousYear;
        public Dictionary<string, IAsset> AssetsEndOfYear => this.assetsEndOfYear;
    }
}
