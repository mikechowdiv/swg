using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    //function to load a product by product type.

    public interface IProdRepo
    {
        Product GetProduct(string productType);
    }
}
