using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL;

namespace PaperRockSissor
{
    public class ConsoleOutput
    {
       public static void PrintResultText(PlayerRoundResponse result)
        {
            Console.WriteLine("You picked {0}, the computer picked {1}", Enum.GetName(typeof(Choice), result.UserChoice),
                Enum.GetName(typeof(Choice), result.ComputerChoice));

            switch (result.Result)
            {
                case GameResult.Win:
                    Console.WriteLine("You won!");
                    break;
                case GameResult.Loss:
                    Console.WriteLine("You Lose!");
                    break;
                default:
                    Console.WriteLine("It's a draw!");
                    break;

            }
        }
    }
}
