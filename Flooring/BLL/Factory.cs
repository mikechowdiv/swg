using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Repo;
using Data.TestRepo;
using Models.Interfaces;

namespace BLL
{
   public static class Factory
    {
        public static OrderMgr GetOrderRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
            {
                case "TEST":
                    return new OrderMgr(new TestOrderRepo());
                default: return new OrderMgr(new OrderRepo());
            }
        }

        public static ProductMgr GetProdRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
           
            {
                case "TEST": return new ProductMgr(new TestProdRepo());
                default: return new ProductMgr(new ProductRepo());
            }
        }

        public static TaxMgr GetTaxRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            switch (mode)
            {
                case "TEST": return new TaxMgr(new TestTaxRepo());
                default: return new TaxMgr(new TaxRepo());
            }
        }
       
    }
}
