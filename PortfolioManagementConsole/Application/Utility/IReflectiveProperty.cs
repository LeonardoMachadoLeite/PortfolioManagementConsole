using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Application.Utility
{
    public interface IReflectiveProperty
    {
        public object GetProperty(string propertyName);
    }
}
