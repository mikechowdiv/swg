using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooringv1.Workflows
{
    public class Utility
    {
        public DateTime inputDate()
        {
            Console.WriteLine("input a date (mm/dd/yyyy): ");
            DateTime date;
            string userDate = Console.ReadLine();
            while (!DateTime.TryParse(userDate, out date))
            {
                Console.WriteLine("Incorrect format. Please try again. ");
                userDate = Console.ReadLine();
            }
            return date;
        }

        public int InputOrderNumber()
        {
            Console.Write("Input the order number: ");
            string userOrderNumber = Console.ReadLine();
            int orderNumber;
            while (!int.TryParse(userOrderNumber, out orderNumber))
            {
                Console.Write("Input a valid number: ");
                userOrderNumber = Console.ReadLine();
            }
            return orderNumber;
        }
    }
}
