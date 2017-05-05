using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL;

namespace PaperRockSissor
{
    class ConsoleInput
    {
        public static Choice GetChoiceFromUser()
        {
            Console.Clear();
            Console.Write("Enter your choice (R)ock, (P)aper, or (S)cissors: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "P":
                    return Choice.Paper;
                case "S":
                    return Choice.Scissors;
                default:
                    return Choice.Rock;
            }
        }    
    }
}
