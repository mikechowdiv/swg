using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data.TestRepo
{
    public class TestTaxRepo : IStateRepo
    {
        List<StateTax> st = new List<StateTax>();

        public StateTax GetTaxes(string stateAbb)
        {
            StateTax tax = null;
            foreach (StateTax items in st)
            {
                if (items.StateAbb == stateAbb)
                {
                    tax = items;
                }
            }
            return tax;
        }

        public TestTaxRepo()
        {
            StateTax t1 = new StateTax("OH", 3.2m);
            StateTax t2 = new StateTax("IN",2.0m);
            st.Add(t1);
            st.Add(t2);
        }
    }
}
