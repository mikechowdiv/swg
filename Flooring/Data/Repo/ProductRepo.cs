using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data
{
    public class ProductRepo : IProdRepo
    {
        public Product GetProduct(string productType)
        {
            List<Product> prod = GetProducts();
            Product product = null;
            foreach (Product items in prod)
            {
                if (items.ProductType.ToUpper() == productType.ToUpper())
                {
                    product = items;
                }
            }
            return product;
        }

        private List<Product> GetProducts()
        {
            List<Product> prod = new List<Product>();
            bool exists = File.Exists(getPath());
            if (exists)
            {
                string[] splitProduct;
                string prodstr;
                using (var stream = File.OpenRead(getPath()))
                using (var reader = new StreamReader(stream))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        prodstr = reader.ReadLine();
                        splitProduct = prodstr.Split(',');
                        string productType = splitProduct[0];
                        decimal costPerFoot;
                        decimal.TryParse(splitProduct[1], out costPerFoot);
                        decimal laborPerFoot;
                        decimal.TryParse(splitProduct[2], out laborPerFoot);
                        Product products = new Product(productType, costPerFoot, laborPerFoot);
                        prod.Add(products);
                    }
                }
            }
            return prod;
        }

        private string getPath()
        {
            return (@"E:\workspace\SG-works\week5 project\Flooring2.7\Products.txt");
        }


        private string _path = @"E:\workspace\SG-works\week5 project\Flooring2.7\Products.txt";

    }
}
