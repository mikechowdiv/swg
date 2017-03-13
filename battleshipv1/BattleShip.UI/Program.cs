using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Game Game = new Game();
                Game.Start();
                Console.Clear();
                Console.WriteLine("Play again? Y/N");
            } while (Console.ReadLine().ToLower() == "y");
                
               
        }

    }

}