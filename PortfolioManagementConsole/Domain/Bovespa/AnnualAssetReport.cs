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
        private List<IAsset> listaAtivosAnoAnterior;
        private List<IAsset> listaAtivosFinalAno;

        public AnnualAssetReport(int year)
        {
            this.year = year;
            this.listaAtivosAnoAnterior = new List<IAsset>();
            this.listaAtivosFinalAno = new List<IAsset>();
        }

        public int Year => year;
        public List<IAsset> ListaAtivosAnoAnterior => this.listaAtivosAnoAnterior;
        public List<IAsset> ListaAtivosFinalAno => this.listaAtivosFinalAno;
    }
}
