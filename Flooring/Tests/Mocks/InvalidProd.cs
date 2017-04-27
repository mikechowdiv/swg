using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Tests.Mocks
{
    class InvalidProd : IProdRepo

    {
        public Product GetProduct(string productType)
        {
            Product prod = null;
            return prod;
        }
    }
}
