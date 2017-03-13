using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    //ask for user names
    //ask for coordinate from each player
    //ask for ship direction from each player

    public class ConsoleInput
    {
       
        public Coordinate AskCoordinate(string playerName)
        {          
            while (true)
            {
                Console.WriteLine("Choose an X coordinate A-J");
                string Xcoord = (Console.ReadLine().ToUpper());
               
                int toInt = 0;
                if (Xcoord == "A") toInt = 1;
                else if (Xcoord == "B") toInt = 2;
                else if (Xcoord == "C") toInt = 3;
                else if (Xcoord == "D") toInt = 4;
                else if (Xcoord == "E") toInt = 5;
                else if (Xcoord == "F") toInt = 6;
                else if (Xcoord == "G") toInt = 7;
                else if (Xcoord == "H") toInt = 8;
                else if (Xcoord == "I") toInt = 9;
                else if (Xcoord == "J") toInt = 10;
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a letter A-J");
                    Console.WriteLine("");
                }

                {                
                    while (true)
                    {
                        Console.WriteLine("Choose a Y coordinate 1-10");
                        string userY = Console.ReadLine();
                        int inputY;
                        while (!int.TryParse(userY, out inputY))
                        {
                            Console.WriteLine("You need to input a number");
                            userY = Console.ReadLine();
                        }                       

                        if (inputY > 0 && inputY < 11)
                        {                          
                            return new Coordinate(toInt, inputY);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("You need to input a number from 1-10");
                            Console.WriteLine("");
                        }
                    }
                }             
            }
        }

        public ShipDirection AskShipDirection(string playerName)
        {
            while (true)
            {
                Console.WriteLine("{0} please choose the direction of your ship. Enter U,D,L or R", playerName);
                string input = Console.ReadLine();
                switch (input.ToUpper())
                {
                    case "U":
                        return ShipDirection.Up;
                    case "D":
                        return ShipDirection.Down;
                    case "L":
                        return ShipDirection.Left;
                    case "R":
                        return ShipDirection.Right;
                    default:
                        Console.WriteLine("{0} sorry your input is invalid. Please try again.", playerName);
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
        }

        public static bool PlayAgain()
        {
            bool isValid = false;
            Console.WriteLine("Would you like to play again? (Y)es or hit enter to exit");
            string playAgain = Console.ReadLine();
            if (playAgain != null)
            {
                if (playAgain.ToUpper() == "Y")
                {
                    isValid = true;
                    Console.Clear();
                }
            }
            return isValid;
        }
    }
}
