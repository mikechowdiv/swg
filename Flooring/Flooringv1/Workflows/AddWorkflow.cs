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
    //Load the manager to look up the date. Ask the factory to felch the manager object.
    //Factory will check the AppConfig file.

    public class AddWorkflow
    {        
        public void Start()
        {
                 
                OrderMgr orderManager = Factory.GetOrderRepo();

                //1. Customer Name
                Console.WriteLine("Please enter customer's name: ");
                string custName = Console.ReadLine();
                while (custName == "")
                {
                    Console.WriteLine("Please input a name: ");
                    custName = Console.ReadLine();
                }
                Utility ut = new Utility();
                DateTime date = ut.inputDate();

                //2. State info
                Console.WriteLine("Please enter state: ");
                string stateAbb = Console.ReadLine().ToUpper();
                while (stateAbb.Length != 2)
                {
                    Console.WriteLine("Please input a 2 letter state abbreviation: ");
                    stateAbb = Console.ReadLine().ToUpper();
                }

               // TaxResponse tResp = taxManager.GetTaxes(stateAbb);
                TaxMgr Tmgr = Factory.GetTaxRepo();
                TaxResponse tResp = Tmgr.GetTaxes(stateAbb);
                if (!tResp.Success)
                {
                    orderManager.AddToError(tResp.Message);
                    Console.WriteLine(tResp.Message);
                    Console.ReadKey();
                    return;
                }

                StateTax newTax = tResp.StateTax;

                //3. Product ordered:
                Console.WriteLine("Input the product ordered: ");
                string productType = Console.ReadLine();
                while (productType == "")
                {
                    Console.WriteLine("Please input a product type: ");
                    productType = Console.ReadLine();
                }

                ProductMgr productManager = Factory.GetProdRepo();
                ProductResponse pResp = productManager.GetProduct(productType);
                Product newProd = pResp.Product;
                if (!pResp.Success)
                {
                    orderManager.AddToError(pResp.Message);
                    Console.WriteLine(pResp.Message);
                    Console.ReadKey();
                    return;
                }


                //4. Area ordered: 
                Console.WriteLine("Please input the area ordered: ");
                decimal area;
                string userArea = Console.ReadLine();
                while (!decimal.TryParse(userArea, out area) || area <= 0)
                {
                    Console.WriteLine("Invalid input. Please re-try. ");
                    userArea = Console.ReadLine();
                }

                //Display the order
                Console.WriteLine("\nCustomer name: " + custName);
                Console.WriteLine("Date: " + date);
                Console.WriteLine("State: " + stateAbb);
                Console.WriteLine("Product: " + productType);
                Console.WriteLine("Area: " + userArea);
                Console.WriteLine("Tax: " );
                Console.WriteLine("Confirm to save the information (Y/N)?");
                string confirmation = Console.ReadLine().ToUpper();
                while (confirmation != "Y" && confirmation != "N")
                {
                    Console.WriteLine("Invalid input. Please re-try: ");
                    confirmation = Console.ReadLine();
                }
                if (confirmation == "Y")
                {
                    Order newOrder = new Order(custName, newProd, newTax, area, date);
                    orderManager.AddOrder(newOrder);
                }
            
        }

       
    }
}
