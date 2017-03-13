using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterGuessingGame
{
    public class ConsoleInput
    {
        public static int GetGuessFromUser()
        {
            Console.Clear();
            int output;
            string input;

            while (true)
            {
                Console.Write("enter a guess between 1 and 20");
                input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("that was not a valid number. press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
