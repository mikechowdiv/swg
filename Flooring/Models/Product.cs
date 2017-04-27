using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public string ProductType { get; set; }
        public decimal CostSF { get; set; }
        public decimal LaborSF { get; set; }

        public Product(string prod, decimal mat, decimal labor)
        {
            ProductType = prod;
            CostSF = mat;
            LaborSF = labor;
        }
    }
}
