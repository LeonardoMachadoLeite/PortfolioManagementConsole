using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class FII : Asset
    {
        public FII(string ticker) : base(ticker, "FII's")
        {
        }
    }
}
