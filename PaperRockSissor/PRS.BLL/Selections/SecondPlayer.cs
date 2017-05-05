using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRS.BLL.Interfaces;

namespace PRS.BLL.Selections
{
    public class SecondPlayer : IChoiceGetter
    {
        public Choice GetChoice()
        {
            Console.WriteLine("Enter Choice: (R)ock, (P)aper or (S)cissors");

            string input = Console.ReadLine();

            if(input == "R")
                return Choice.Rock;
            else if(input == "P")
                    return Choice.Paper;
            else
           return Choice.Scissors;
        }
    }
}
