using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Game
    {
        private Board b1;
        private Board b2;
        private string[] playerNames = new string[2];
        private ConsoleOutput display = new ConsoleOutput();
        private ConsoleInput ci = new ConsoleInput();
        private Player pr = new Player();
        private bool gameOver;
        private bool keepPlaying;
       
        public void Start()
        {
            gameOver = false;
            keepPlaying = true;
            displayScreen(); 
            askPlayer();
            createBoard(); 
            createShips(); //create ships + replace ships
            runGame();                      
        }

        private void createShips()
            //loop to place ships on boards
        {
            for (int i = 0; i < 2; i++) //player loop.  2 players
            {
                for (int j = 0; j < 5; j++) //ship loop.  5 ships each player
                {
                    if (i == 0)
                    {
                        putShips(playerNames[i], b1, (ShipType) j);
                    }
                    else
                    {
                        putShips(playerNames[i],b2,(ShipType)j);
                    }
                }
            }
        }

        private void askPlayer()
        //feed to ConsoleInput to get players names. Names stored in array.
        {
            playerNames[0] = pr.PlayerNameInput("Player 1");
            playerNames[1] = pr.PlayerNameInput("Player 2");
        }

        private void displayScreen()
        {
          display.displayScreen();
        }

        private void createBoard()
            //create boards
        {
            b1 = new Board();
            b2 = new Board();
        }

        //putShip method is called with createShip() after taking each player's names.
        private void putShips(string playerName, Board board, ShipType type)
        {
            Console.Clear();
            PlaceShipRequest request = new PlaceShipRequest();
            while (true)
            {
                //tell the user to place ship and what ship they are placing.
                //based on the ship eunm.              
                Console.WriteLine($"{playerName} place your " + type);

                Coordinate coordinate = ci.AskCoordinate(playerName);
                ShipDirection direction = ci.AskShipDirection(playerName);
                request.ShipType = type;
                //call the coordinate method and the direction method for each ship placement
                request.Coordinate = coordinate;
                request.Direction = direction;

                //using the ship placement enum in a switch statement to tell the user ship placement ok or not
                //if not keep asking until a valid input is made.

                ShipPlacement sp = board.PlaceShip(request);
                switch (sp)
                {
                    case ShipPlacement.Ok:
                        return;
                    case ShipPlacement.Overlap:
                        Console.WriteLine($"{playerName}, space taken. Please re-try");
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        Console.WriteLine($"{playerName}, not enough space. Please re-try ");
                        break;
                    default:
                        Console.WriteLine("What happened?");
                        break;
                }              
            }
        }

        private void runGame()
        {
            while (!gameOver)
            {
                if (keepPlaying)
                {
                    display.displayBoard(b2);
                    gameOver = playRun(playerNames[0], b2);
                }
                else
                {
                    display.displayBoard(b1);
                    gameOver = playRun(playerNames[1], b1);
                }
                keepPlaying = !keepPlaying;
            }
        }

        private bool playRun(string playerName, Board board)
        {
            bool keepPlay = true;
            while (keepPlay)
            {
                Console.WriteLine($"{playerName}, please enter the coordinate of your target");
                Coordinate XY = ci.AskCoordinate(playerName);
                FireShotResponse response = board.FireShot(XY);

                switch (response.ShotStatus)
                {
                        case ShotStatus.Invalid:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;

                        case ShotStatus.Hit:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You hit a {0}. Press any key to continue. ", response.ShipImpacted);
                        Console.ResetColor();
                        Console.ReadKey();
                        keepPlay = false;
                        return false;
                        
                        case ShotStatus.Miss:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You missed. Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadKey();
                        keepPlay = false;
                        return false;
                        
                        case ShotStatus.Duplicate:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You already hit that area. Press any key to continue.");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;                       
                        
                        case ShotStatus.HitAndSunk:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You sunk a {0}. Press any key to continue.", response.ShipImpacted);
                        Console.ResetColor();
                        Console.ReadKey();
                        keepPlay = false;
                        return false;
                        
                        case ShotStatus.Victory:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You win.");
                        Console.WriteLine("Enter Q to quit or hit any key to continue.");
                        Console.ResetColor();
                        string quit = (Console.ReadLine().ToUpper());
                        if (quit == "Q")
                        {
                            return true;
                        }
                        else
                        {
                            Start();
                            return false;
                        }
                }              
            }
            return true;
        }
    }
}
