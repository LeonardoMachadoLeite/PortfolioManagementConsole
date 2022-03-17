using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioManagementConsole.Model.Investor
{
    internal abstract class Investor
    {
        private readonly int _id;
        private string name;
        private DateTime birthDate;

        protected Investor(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public string Name { get => name; set => name = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public int Id => _id;
    }
}
