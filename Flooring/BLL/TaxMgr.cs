using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using Models.Responses;

namespace BLL
{
   public class TaxMgr
   {
       private IStateRepo repo;

       public TaxMgr(IStateRepo repo)
       {
           this.repo = repo;
       }

       public TaxResponse GetTaxes(string stateAbb)
       {
           StateTax tax = repo.GetTaxes(stateAbb);
            TaxResponse resp = new TaxResponse();
           if (tax == null)
           {
               resp.Success = false;
               resp.Message = "Do not have tax info for this state...";
           }
           else
           {
               resp.Success = true;
               resp.StateTax = tax;
           }
           return resp;
       }
   }
}
