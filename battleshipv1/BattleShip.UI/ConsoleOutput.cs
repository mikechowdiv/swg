using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
        public void displayScreen()
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("");
            Console.WriteLine(@"
 ______   _______ __________________ _        _______  _______          _________ _______ 
(  ___ \ (  ___  )\__   __/\__   __/( \      (  ____ \(  ____ \|\     /|\__   __/(  ____ )
| (   ) )| (   ) |   ) (      ) (   | (      | (    \/| (    \/| )   ( |   ) (   | (    )|
| (__/ / | (___) |   | |      | |   | |      | (__    | (_____ | (___) |   | |   | (____)|
|  __ (  |  ___  |   | |      | |   | |      |  __)   (_____  )|  ___  |   | |   |  _____)
| (  \ \ | (   ) |   | |      | |   | |      | (            ) || (   ) |   | |   | (      
| )___) )| )   ( |   | |      | |   | (____/\| (____/\/\____) || )   ( |___) (___| )      
|/ \___/ |/     \|   )_(      )_(   (_______/(_______/\_______)|/     \|\_______/|/       
                                                                                          ");
            Console.WriteLine();          
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        public void displayBoard(Board board)
        {
            Console.Clear();
            //header for x axis
            Console.Write("   ");
            for (char i = 'A'; i < 'K'; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine("");
            //x axis
            for (int i = 1; i < 11; i++)
            {
                //elements in the x axis creating a y column that is the y axis.
                Console.Write("{0} ", i.ToString().PadLeft(2));
                for (int j = 1; j < 11; j++)
                {
                    Coordinate coordinate = new Coordinate(j, i);

                    //check shot History
                    bool shotHistory = board.ShotHistory.ContainsKey(coordinate);
                    

                    //Filling in the board with "H" where hits have occured, "M" where misses have
                    //occured, and "~" where there is no shot history.
                    if (shotHistory == true)
                    {
                        switch (board.ShotHistory[coordinate])
                        {
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.Red;                               
                                Console.Write("H ");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("M ");
                                Console.ResetColor();
                                break;
                            case ShotHistory.Unknown:
                                
                                Console.Write("? ");
                                break;
                            default:
                                Console.WriteLine("invalid input...");
                                break;
                        }
                    }
                    else
                    {
                        Console.Write("~ ");

                    }
                }
                Console.WriteLine("");
            }
        }


    }
}
