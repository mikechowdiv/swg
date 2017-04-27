using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StateTax
    {
        public string StateAbb { get; set; }
        public decimal TaxRate { get; set; }

        public StateTax(string state, decimal tax)
        {
            StateAbb = state;
            TaxRate = tax;
        }
    }
}
