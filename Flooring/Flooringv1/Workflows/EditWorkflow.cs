using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Data;
using Data.Repo;
using Models;
using Models.Interfaces;
using Models.Responses;

namespace Flooringv1.Workflows
{
   public class EditWorkflow
    {
        

        public void Start()
        {
            OrderMgr orderManager = Factory.GetOrderRepo();

            Utility ut = new Utility();
            DateTime dt = ut.inputDate();
            int orderNum = ut.InputOrderNumber();
            OrderResponse oResp = orderManager.EditOrder(dt, orderNum);
            if (!oResp.Success)
            {
                Console.WriteLine(oResp.Message);
                Console.ReadKey();
                return;
            }

            Order edit = oResp.Order;
            Console.WriteLine("Edit customer name or hit Enter to continue...");
            string userInput = Console.ReadLine();
            string newName;
            if (userInput == "")
            {
                newName = edit.CustName;
            }
            else
            {
                newName = userInput;
            }

            Console.WriteLine("Edit order date or hit Enter to continue...");
            DateTime newDate;
            string userDate = Console.ReadLine();
            if (userDate == "")
            {
                newDate = edit.Date;
            }
            else
            {
                while (!DateTime.TryParse(userDate, out newDate))
                {
                    Console.WriteLine("Incorrect format. Please input a date (MM/DD/YYYY):");
                    userDate = Console.ReadLine();
                }
            }

            Console.WriteLine("Edit State or hit Enter to continue...");
            userInput = Console.ReadLine();
            StateTax newState;
            TaxMgr taxManager = Factory.GetTaxRepo();
            if (userInput == "")
            {
                newState = edit.STax;
            }
            else
            {
                while (userInput.Length != 2)
                {
                    Console.WriteLine("Please enter a 2-letter state abbreviation...");
                    userInput = Console.ReadLine();
                }
                TaxResponse taxResponse = taxManager.GetTaxes(userInput);
                if (!taxResponse.Success)
                {
                    orderManager.AddToError(taxResponse.Message);
                    Console.WriteLine(taxResponse.Message);
                    Console.ReadKey();
                    return;
                }
                newState = taxResponse.StateTax;

            }

            Console.WriteLine("Edit product or hit Enter to continue...");
            userInput = Console.ReadLine();
            Product newProd;
            ProductMgr productManager = Factory.GetProdRepo();
            if (userInput == "")
            {
                newProd = edit.Product;
            }
            else
            {
                ProductResponse pResp = productManager.GetProduct(userInput);
                if (!pResp.Success)
                {
                    orderManager.AddToError(pResp.Message);
                    Console.WriteLine(pResp.Message);
                    Console.ReadKey();
                    return;
                }
                newProd = pResp.Product;
            }

            Console.WriteLine("Edit area or hit enter to continue...");
            userInput = Console.ReadLine();
            decimal newArea;
            if (userInput == "")
            {
                newArea = edit.Area;
            }
            else
            {
                while (!decimal.TryParse(userInput, out newArea) || newArea <= 0)
                {
                    Console.WriteLine("Invalid input.  Please re-try.");
                    userInput = Console.ReadLine();
                }             
            }

            Order newOrder = new Order(
                newName,
                newProd,
                newState,
                newArea,
                newDate
                );
            newOrder.OrderNum = orderNum;
            orderManager.DeleteOrder(dt, orderNum);
            orderManager.AddOrder(newOrder);

        }
    }
}
