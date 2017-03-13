using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer
{
    class ConsoleOutput
    {
        public static void ReportFactors(int factor, int[] numbers)
        {
            if(numbers.Length < 1)
                Console.WriteLine($"Getting the factor for 0 is complicated....");
            else
                Console.WriteLine($"The factors of {factor} are {FormatNumbers(numbers)}");
        }

        public static void ReportAttribte(int number, bool hasAttribute, string attribute)
        {
            string not = hasAttribute ? "" : "not ";
            Console.WriteLine($"The number {number} is {not}{attribute}. ");
        }

        private static string FormatNumbers(int[] factors)
        {
            if (factors.Length == 0) return "none";
            string result = "";
            for (int i = 0; i < factors.Length; i++)
            {
                result += factors[i];
                if (i < factors.Length - 2)
                    result += ", ";
                else if (i == factors.Length - 2)
                {
                    result += " and ";
                }
            }
            return result;

        }
    }
}
