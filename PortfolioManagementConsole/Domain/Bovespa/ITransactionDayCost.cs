using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    public interface ITransactionDayCost
    {
        public DateTime TransactionDay { get; }

        public double LiquidationRate { get; }

        public double RegistryRate { get; }

        public double OptionsRate { get; }

        public double ANARate1 { get; }

        public double Fees { get; }

        public double OperationRate { get; }

        public double ExecutionCost { get; }

        public double CustodyRate { get; }

        public double Tax { get; }

        public double OtherFees { get; }

        public string GetJson();
    }
}
