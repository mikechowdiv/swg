using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class PerfectChecker
    {
        //prefectchecker should have a method that returns a boolean indicating whether a number is prefect

        public static bool isPerfect(int x)
        {
            if (x == 0) return false;
            int[] factors = FactorFinder.GetFactors(x);
            int sum = 0;
            for (int i = 0; i < factors.Length - 1; i++)
            {
                sum += factors[i];
            }
            return sum == x;
        }
    }
}
