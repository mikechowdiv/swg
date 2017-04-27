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
    public class ProductMgr
    {
        private IProdRepo repo;

        public ProductMgr(IProdRepo repo)
        {
            this.repo = repo;
        }

        public ProductResponse GetProduct(string productType)
        {
            Product prod = repo.GetProduct(productType);
            ProductResponse resp = new ProductResponse();
            if (prod == null)
            {
                resp.Success = false;
                resp.Message = "No info for this product...";
            }
            else
            {
                resp.Success = true;
                resp.Product = prod;
            }
            return resp;
        }
    }
}
