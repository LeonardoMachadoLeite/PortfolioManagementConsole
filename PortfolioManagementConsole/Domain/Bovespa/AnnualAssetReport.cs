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
    public class AnnualAssetReport
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

        private AnnualAssetReport(int year, Dictionary<string, IAsset> assetsEndOfPreviousYear)
        {
            this.year = year;
            this.assetsEndOfPreviousYear = new Dictionary<string, IAsset>(assetsEndOfPreviousYear);
            this.assetsEndOfYear = new Dictionary<string, IAsset>();
            foreach (var asset in assetsEndOfPreviousYear)
            {
                this.assetsEndOfYear[asset.Key] = new Acao((Acao)asset.Value);
            }
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
            if (!assets.ContainsKey(transaction.Ticker))
            {
                assets[transaction.Ticker] = new Acao(transaction.Ticker);
            }
            assets[transaction.Ticker].ProcessOrder(transaction);
        }

        public AnnualAssetReport CreateBaseForNextYearReport()
        {
            return new AnnualAssetReport(year + 1, this.assetsEndOfYear);
        }

        public IExcelSheetTable CreateAnnualAssetReportSheetTable()
        {
            return new ExcelSheetTable(Convert.ToString(this.year), AnnualAssetDetail.GetHeaders());
        }

        public Dictionary<string, IReflectiveProperty> GetAnnualAssetDetails()
        {
            Dictionary<string, IReflectiveProperty> dict = new Dictionary<string, IReflectiveProperty>();
            IAsset assetEndOfPreviousYear, asset;


            foreach (var ticker in this.assetsEndOfYear.Keys)
            {
                if (RelevantTickerForYear(ticker))
                {
                    if (!this.assetsEndOfPreviousYear.ContainsKey(ticker))
                    {
                        assetEndOfPreviousYear = null;
                    }
                    else
                    {
                        assetEndOfPreviousYear = this.assetsEndOfPreviousYear[ticker];
                    }

                    asset = this.assetsEndOfYear[ticker];
                    dict[ticker] = new AnnualAssetDetail(ticker,
                                                   assetEndOfPreviousYear,
                                                   asset);
                }
            }

            return dict;
        }

        private bool RelevantTickerForYear(string ticker)
        {
            double amountPreviousYear = 0, amountEndOfCurrentYear = 0;

            if (this.assetsEndOfPreviousYear.ContainsKey(ticker))
            {
                amountPreviousYear = this.assetsEndOfPreviousYear[ticker].Amount;
            }

            if (this.assetsEndOfYear.ContainsKey(ticker))
            {
                amountEndOfCurrentYear = this.assetsEndOfYear[ticker].Amount;
            }

            return amountPreviousYear != 0 || amountEndOfCurrentYear != 0;
        }

        public int Year => year;
        public Dictionary<string, IAsset> AssetsEndOfPreviousYear => this.assetsEndOfPreviousYear;
        public Dictionary<string, IAsset> AssetsEndOfYear => this.assetsEndOfYear;
    }
}
