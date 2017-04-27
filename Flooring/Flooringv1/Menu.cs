using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Flooringv1.Workflows;

namespace Flooringv1
{
    public class Menu
    {
        public void Start()
        {
            do
            {
                DisplayMenu();
                int input = getInput();
                runInput(input);
            } while (true);

        }

        private void runInput(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayWorkflow display = new DisplayWorkflow();
                    display.Start();
                    break;
                case 2:
                    AddWorkflow add = new AddWorkflow();
                    add.Start();
                    break;
                case 3:
                    EditWorkflow edit = new EditWorkflow();
                    edit.Start();
                    break;
                case 4:
                    RemoveWorkflow remove = new RemoveWorkflow();
                    remove.Start();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        private int getInput()
        {
            do
            {
                var input = Console.ReadLine();
                int answer;
                if (int.TryParse(input, out answer))
                {
                    if (answer > 0 && answer < 6)
                    {
                        return answer;
                    }
                    Console.WriteLine("Please input: ");
                }
                Console.WriteLine("Invalid Input. Press any key to continue: ");
                Console.ReadKey();
                Console.Clear();
                DisplayMenu();
            } while (true);
        }

        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Flooring!");
            Console.WriteLine("1. Display Order");
            Console.WriteLine("2. Add Order");
            Console.WriteLine("3. Edit Order");
            Console.WriteLine("4. Remove Order");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter Choice: ");
        }


    }
}
