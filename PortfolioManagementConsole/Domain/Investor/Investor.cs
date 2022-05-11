using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Domain.Investor
{
    internal abstract class Investor
    {
        private readonly int _id;
        private string name;
        private DateTime birthDate;

        protected Investor(int _id, string name, DateTime birthDate)
        {
            this._id = _id;
            this.name = name;
            this.birthDate = birthDate;
        }

        public string Name { get => name; set => name = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public int Id => _id;
    }
}
