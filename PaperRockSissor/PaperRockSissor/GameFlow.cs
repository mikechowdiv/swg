using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PRS.BLL;
using PRS.BLL.Selections;

namespace PaperRockSissor
{
    class GameFlow
    {
        public void Start()
        {
            string input;
            GameManager Game;

            Console.Write("(W)eighted mode, (R)andom mode, or (2) player mode? ");
            input = Console.ReadLine();

            if (input == "W")
                Game = new GameManager(new Weighted());
            else if (input == "2")
                Game = new GameManager(new SecondPlayer());
            else
                Game = new GameManager(new RandomChoice());

            do
            {
                Choice userChoice = ConsoleInput.GetChoiceFromUser();
                var result = Game.PlayerRound(userChoice);

                ConsoleOutput.PrintResultText(result);

                Console.WriteLine("Press Q to quit");
                input = Console.ReadLine();
            } while (input != "Q");
        }

        
    }
}
