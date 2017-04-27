using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;
using Models.Responses;

namespace BLL
{
   public class OrderMgr
   {
       private List<string> errors;

       private IOrderRepo Orepo;

        //constructor injection to force whoever to instantiate an acct mgr to provide an acct repo.
        public OrderMgr(IOrderRepo Orepo)
        {
            this.Orepo = Orepo;
            errors = new List<string>();
       }


       public List<Order> GetOrders(DateTime date)
       {
           return Orepo.GetOrder(date);
       }

       public void AddOrder(Order order)
       {
           Orepo.AddOrder(order);
       }

       public OrderResponse DeleteOrder(DateTime date, int orderNum)
       {
           bool success = Orepo.DeleteOrder(date, orderNum);
            OrderResponse resp = new OrderResponse();
           resp.Success = success;
           if (success)
           {
               resp.Message = "Order deleted";
           }
           else
           {
               resp.Message = "Cannot find the order...";
               AddToError(resp.Message);
           }
           return resp;
       }

       public OrderResponse EditOrder(DateTime dt, int orderNum)
       {
           Order order = Orepo.EditOrder(dt, orderNum);
            OrderResponse resp = new OrderResponse();
           if (order == null)
           {
               resp.Success = false;
               resp.Message = "Cannot find the order to edit...";
                AddToError(resp.Message);
           }
           else
           {
               resp.Success = true;
               resp.Message = "Order found";
               resp.Order = order;
           }
           return resp;
       }

        public void AddToError(string err)
        {
           errors.Add(err);
            string errorFile = (@"E:\workspace\SG-works\week5 project\Flooring2.7\Errors.txt");
            File.Delete(errorFile);
            foreach (string items in errors)
            {
                File.AppendAllText(errorFile,items + Environment.NewLine);                
            }
        }
    }
}
