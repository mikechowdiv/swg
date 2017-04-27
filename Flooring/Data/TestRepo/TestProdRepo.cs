using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data.TestRepo
{
    public class TestProdRepo : IProdRepo
    {
      

        List<Product> products = new List<Product>();
        public TestProdRepo()
        {
            Product p1 = new Product("Tile",5.0m, 3.0m);
            Product p2 = new Product("Wood", 10.0m, 12.0m);
            products.Add(p1);
            products.Add(p2);
        }

        public Product GetProduct(string productType)
        {
            Product prod = null;
            foreach (Product items in products)
            {
                if (items.ProductType.ToUpper() == productType.ToUpper())
                {
                    prod = items;
                }
            }
            return prod;

        }
    }
}
