using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class PrimeChecker
    {
        public static bool isPrime(int x)
        {
            return FactorFinder.GetFactors(x).Length == 2;
        }
    }
}
