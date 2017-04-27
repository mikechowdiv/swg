using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data.TestRepo
{
    public class TestOrderRepo : IOrderRepo
    {
        List<Order> orders = new List<Order>();
        public TestOrderRepo()
        {
            Product pd = new Product("Wood", 10m, 19m);
            StateTax tax = new StateTax("IN", 3m);
            Order o1 = new Order("Mary", pd, tax, 10m, new DateTime(01/01/2000));
            orders.Add(o1);
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public bool DeleteOrder(DateTime date, int orderNum)
        {
            Order od = null;
            foreach (Order items in orders)
            {
                if (items.Date == date && items.OrderNum == orderNum)
                {
                    od = items;
                }
            }
            if (od == null)
            {
                return false;
            }
            orders.Remove(od);
            return true;
        }

        public Order EditOrder(DateTime date, int orderNum)
        {
            Order od = null;
            foreach (Order items in orders)
            {
                if (items.Date == date && items.OrderNum == orderNum)
                {
                    od = items;
                }
            }
            return od;
        }

        public List<Order> GetOrder(DateTime date)
        {
            return orders;
        }
    }
}
