using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;

namespace BetterGuessingGame
{
   public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("welcome to Guessing Game");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void DisplayGuessMessage(GuessResult result)
        {
            switch (result)
            {
                    case GuessResult.Win:
                    DisplayVictory();
                    break;
                    case GuessResult.Higher:
                    DisplayHigher();
                    break;
                    case GuessResult.Lower:
                    DisplayLower();
                    break;
                    case GuessResult.Invalid:
                    DisplayInvalid();
                    break;
            }
        }

        private static void DisplayHigher()
        {
            Console.WriteLine("too low");
            Console.ReadKey();
        }

        private static void DisplayLower()
        {
            Console.WriteLine("too high ");
            Console.ReadKey();
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("invalid input");
            Console.ReadKey();
        }

        private static void DisplayVictory()
        {
            Console.WriteLine("you won");
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
