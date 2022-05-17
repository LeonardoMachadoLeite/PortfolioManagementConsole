using PortfolioManagementConsole.Application.Utility;
using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class AnnualAssetDetail : IReflectiveProperty
    {

        public AnnualAssetDetail(string ticker, IAsset assetPreviousYear, IAsset assetCurrentYear)
        {
            this.Ticker = ticker;

            if (assetPreviousYear is not null)
            {
                this.AmountPreviousYear = Convert.ToString(assetPreviousYear.Amount);
                this.AquisitionPricePreviousYear = ConvertToCurrency(assetPreviousYear.AvgPrice * assetPreviousYear.Amount);
            }
            else
            {
                this.AmountPreviousYear = "0";
                this.AquisitionPricePreviousYear = "0,00";
            }

            this.AmountCurrentYear= Convert.ToString(assetCurrentYear.Amount);
            this.AquisitionPriceCurrentYear = ConvertToCurrency(assetCurrentYear.AvgPrice * assetCurrentYear.Amount);
        }

        public string Ticker { get; }
        public string AquisitionPricePreviousYear { get; }
        public string AmountPreviousYear { get; }
        public string AquisitionPriceCurrentYear { get; }
        public string AmountCurrentYear { get; }

        private string ConvertToCurrency(double value)
        {
            return String.Format("{0:N}", value);
        }

        public object GetProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "Ticker":
                    return this.Ticker;
                case "Preço de Aquisição Ano Anterior":
                    return this.AquisitionPricePreviousYear;
                case "Quantidade Ano Anterior":
                    return this.AmountPreviousYear;
                case "Preço de Aquisição Ano Atual":
                    return this.AquisitionPriceCurrentYear;
                case "Quantidade Ano Atual":
                    return this.AmountCurrentYear;
                default:
                    return null;
            }
        }

        public static LinkedList<string> GetHeaders()
        {
            LinkedList<string> headers = new LinkedList<string>();

            headers.AddLast("Ticker");
            headers.AddLast("Preço de Aquisição Ano Anterior");
            headers.AddLast("Quantidade Ano Anterior");
            headers.AddLast("Preço de Aquisição Ano Atual");
            headers.AddLast("Quantidade Ano Atual");

            return headers;
        }
    }
}
