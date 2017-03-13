using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterFactorizer
{
    class ConsoleInput
    {
        public static int AwaitUserInput()
        {
            int number;
            bool parsed = false;
            do
            {
                parsed = int.TryParse(Console.ReadLine(), out number);
                if (!parsed)
                {
                    Console.WriteLine("invalid non-integer input");
                }
            } while (!parsed);
            return number;
        }

        public static bool UserEscapes()
        {
            return Console.ReadKey(intercept: true).Key == ConsoleKey.Escape;
        }
    }
}
