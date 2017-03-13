using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class Player
    {
        public string player;
        public string PlayerNameInput(string player)
        {
            do
            {
                Console.Write("{0} Please enter your name: ", player);
                string yourName = Console.ReadLine();
                Console.WriteLine("");

                if (!string.IsNullOrEmpty(yourName))
                {
                    return yourName;
                }
                //keep asking if no string given.
                {
                    Console.WriteLine("Please enter your name: ");
                    Console.WriteLine("");
                }
            } while (true);
        }
    }
}
