using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    //functions to save, add, delete, edit orders

   public interface IOrderRepo
   {
       List<Order> GetOrder(DateTime date);
       void AddOrder(Order order);
       bool DeleteOrder(DateTime date, int orderNum);
       Order EditOrder(DateTime date, int orderNum);
   }
}
