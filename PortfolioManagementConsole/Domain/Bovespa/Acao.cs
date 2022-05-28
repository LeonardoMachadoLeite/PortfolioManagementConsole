using PortfolioManagementConsole.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Bovespa
{
    internal class Acao : Asset
    {
        public Acao(string ticker) : base(ticker, "Ações")
        {
        }

        public Acao(Acao acao) : base(acao)
        {
        }
    }
}
