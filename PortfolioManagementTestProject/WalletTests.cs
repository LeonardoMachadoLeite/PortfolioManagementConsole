using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortfolioManagementConsole.Domain.Bovespa;
using Xunit;

namespace PortfolioManagementTestProject
{
    public class WalletTests
    {

        [Fact]
        public void CreateAnnualAssetReportsTest()
        {
            //Arrange
            var dirPath = "D:\\Investment Data\\bovespa\\Notas de Corretagem";

            Wallet wallet = new Wallet(dirPath);
            wallet.ConsolidateAnnualAssetReport();

            //Act
            wallet.GenerateAnnualAssetStatements();

            //Assert
            Assert.Equal(1, 1);
        }

    }
}
