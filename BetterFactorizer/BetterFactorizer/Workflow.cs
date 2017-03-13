using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizer.BLL;

namespace BetterFactorizer
{
    class Workflow
    {
        //the workflow should invoke methods to perform tasks.
        //It should not contain any calculations.

        public void Run()
        {
            Console.WriteLine("Welcome to Factorizer");
            do
            {
                Console.WriteLine("Please enter an integer: ");
                int number = ConsoleInput.AwaitUserInput();
                Console.WriteLine();
                ConsoleOutput.ReportFactors(number, FactorFinder.GetFactors(number));
                ConsoleOutput.ReportAttribte(number, PrimeChecker.isPrime(number), "prime");
                ConsoleOutput.ReportAttribte(number,PerfectChecker.isPerfect(number),"prefect");
                Console.WriteLine("Press ESC to quit or any kep to continue");

            } while (!ConsoleInput.UserEscapes());
        }
    }
}
