using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Model.Bovespa
{
    internal class TransactionDayCost
    {
        private readonly DateTime transactionDay;
        private readonly double liquidationRate;
        private readonly double registryRate;
        private readonly double optionsRate;
        private readonly double ANARate;
        private readonly double fees;
        private readonly double operationRate;
        private readonly double executionCost;
        private readonly double custodyRate;
        private readonly double tax;
        private readonly double otherFees;

        public TransactionDayCost(DateTime transactionDay, double liquidationRate, double registryRate, double optionsRate,
            double anaRate, double fees, double operationRate, double executionCost, double custodyRate, double tax, double otherFees)
        {
            this.transactionDay = transactionDay;
            this.liquidationRate = liquidationRate;
            this.registryRate = registryRate;
            this.optionsRate = optionsRate;
            this.ANARate = anaRate;
            this.fees = fees;
            this.operationRate = operationRate;
            this.executionCost = executionCost;
            this.custodyRate = custodyRate;
            this.tax = tax;
            this.otherFees = otherFees;
        }

        public DateTime TransactionDay => this.transactionDay;

        public double LiquidationRate => this.liquidationRate;

        public double RegistryRate => this.registryRate;

        public double OptionsRate => this.optionsRate;

        public double ANARate1 => this.ANARate;

        public double Fees => this.fees;

        public double OperationRate => this.operationRate;

        public double ExecutionCost => this.executionCost;

        public double CustodyRate => this.custodyRate;

        public double Tax => this.tax;

        public double OtherFees => this.otherFees;

        public string GetJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
