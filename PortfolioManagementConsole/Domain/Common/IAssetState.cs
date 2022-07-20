namespace PortfolioManagementConsole.Domain.Common
{
    public interface IAssetState
    {
        public DateTime Date { get; }
        public string Ticker { get; }
        public string AssetType { get; }
        public double Amount { get; }
        public double AvgPrice { get; }
        public double CurrentPrice { get; set; }
    }
}