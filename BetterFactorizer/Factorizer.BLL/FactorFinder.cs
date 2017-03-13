using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizer.BLL
{
    public class FactorFinder
    {
        //FactorFinder should have a method member that returns an array containing the factors
        //of a given number.

        public static int[] GetFactors(int x)
        {
            if(x==0) return new int[0]; //ignore infinite factors of zero

            int posX = Math.Abs(x); //treat negative # as positive
            int[] factors = new int[posX]; //allocate more than needed
            int numFactors = 0; //track how many actually used

            for (int i = 1; i <= posX; i++)
            {
                if (posX % i == 0) //check each divisor and record factors
                {
                    factors[numFactors] = i;
                    numFactors++;
                }
            }

            //return factor array with the right size
            int[] result = new int[numFactors];
            Array.Copy(factors, result, numFactors);
            return result;
        }
    }
}
