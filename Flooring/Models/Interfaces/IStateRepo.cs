using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    //get tax rate by state.

   public interface IStateRepo
   {
       StateTax GetTaxes(string stateAbb);
   }
}
