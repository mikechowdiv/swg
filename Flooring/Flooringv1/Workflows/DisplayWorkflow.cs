using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Data;
using Data.Repo;
using Models;
using Models.Interfaces;

namespace Flooringv1.Workflows
{
    public class DisplayWorkflow
    {
        Utility ut = new Utility();

        
        public void Start()
        {
            DateTime date = ut.inputDate();
            OrderMgr orderManager = Factory.GetOrderRepo();

            List<Order> orders = orderManager.GetOrders(date);
            

            foreach (Order items in orders)
            {
                Console.WriteLine("**************************************");
                Console.WriteLine(items);
            }
            Console.WriteLine("**************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }     
    }
}
