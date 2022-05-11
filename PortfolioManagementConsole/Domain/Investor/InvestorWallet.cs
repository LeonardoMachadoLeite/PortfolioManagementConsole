using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Investor
{
    internal class InvestorWallet
    {
        private readonly int investorId;
        private readonly int walletId;
        private readonly int brokerId;
        private readonly string walletName;
        private readonly string walletCountry;

        public InvestorWallet(int investorId, int walletId, int brokerId, string walletName, string walletCountry)
        {
            this.investorId = investorId;
            this.walletId = walletId;
            this.brokerId = brokerId;
            this.walletName = walletName;
            this.walletCountry = walletCountry;
        }

        public int InvestorId => investorId;

        public int WalletId => walletId;

        public int BrokerId => brokerId;

        public string WalletName => walletName;

        public string WalletCountry => walletCountry;
    }
}
