using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Interfaces;

namespace Data.Repo
{
    public class OrderRepo : IOrderRepo
    {
    
        public void AddOrder(Order order)
        {
            List<Order> orders = GetOrder(order.Date);
           orders.Add(order);
            GetPath(order.Date);
          WriteToFile(orders);
        }

        private void WriteToFile(List<Order> orders)
        {
            File.Delete(_path);
            using (StreamWriter writer = File.CreateText(_path))
            {
                WriteHeader(writer);
                foreach (var items in orders)
                {
                    WriteOrder(items);
                }
            }
        }

        private void WriteOrder(Order newOrder)
        {
            using (StreamWriter writer = File.AppendText(_path))
            {
                writer.Write(Environment.NewLine);
                writer.Write(newOrder.OrderNum + ",");
                writer.Write(newOrder.CustName + ",");
                writer.Write(newOrder.STax.StateAbb + ",");
                writer.Write(newOrder.STax.TaxRate + ",");
                writer.Write(newOrder.Product.ProductType + ",");
                writer.Write(newOrder.Area + ",");
                writer.Write(newOrder.Product.CostSF + ",");
                writer.Write(newOrder.Product.LaborSF + ",");
                writer.Write(newOrder.MatCost + ",");
                writer.Write(newOrder.LaborCost + ",");
                writer.Write(newOrder.TaxCost + ",");
                writer.Write(newOrder.Total + ",");
            }
        }

        private void WriteHeader(StreamWriter writer)
        {
            using (writer)
            {
                writer.Write("OrderNumber,");
                writer.Write("CustomerName,");
                writer.Write("State,");
                writer.Write("TaxRate,");
                writer.Write("ProductType,");
                writer.Write("Area,");
                writer.Write("CostPerSquareFoot,");
                writer.Write("LaborCostPerSquareFoot,");
                writer.Write("MaterialCostTotal,");
                writer.Write("LaborCostTotal,");
                writer.Write("TaxTotal,");
                writer.Write("Total");
            }
        }

        private string _path;  
        private void GetPath(DateTime dt)
        {
            string date = dt.ToString("mmddyyyy");
            _path = string.Format(@"E:\workspace\SG-works\week5 project\Flooring2.7\Orders_{0}.txt", date);
            
        }

        public bool DeleteOrder(DateTime date, int orderNum)
        {
            List<Order> orders = GetOrder(date);
            Order del = null;
            foreach (Order items in orders)
            {
                if (orderNum == items.OrderNum)
                {
                    del = items;
                }
            }
            if (del == null)
            {
                return false;
            }
            orders.Remove(del);
            WriteToFile(orders);
            return true;
        }

        public Order EditOrder(DateTime date, int orderNum)
        {
            List<Order> orders = GetOrder(date);
            Order edit = null;
            foreach (Order items in orders)
            {
                edit = items;
            }
            return edit;
        }

        public List<Order> GetOrder(DateTime date)
        {
            List<Order> orderList = new List<Order>();
           GetPath(date);
            if (File.Exists(_path))
            {

                var reader = File.ReadAllLines(_path);
                for(int i = 1; i < reader.Length; i++)
                {
                    
                        var order = new Order();
                    var split = reader[i].Split(',');
                    

                        order.OrderNum = int.Parse(split[0]);
                        order.Date = date;

                        order.CustName = split[1];

                        decimal taxRate;
                        decimal.TryParse(split[3], out taxRate);

                        decimal matsf;
                        decimal laborsf;
                        decimal.TryParse(split[6], out matsf);
                        decimal.TryParse(split[7], out laborsf);

                        order.STax = new StateTax(split[2], taxRate);

                        order.Product = new Product(split[4], matsf, laborsf);
                        order.Area = decimal.Parse(split[5]);

                        decimal matCost;
                        decimal.TryParse(split[8], out matCost);
                        decimal laborCost;
                        decimal.TryParse(split[9], out laborCost);
                        order.MatCost = matCost;
                        order.LaborCost = laborCost;

                        decimal totalTax;
                        decimal total;
                        decimal.TryParse(split[10], out totalTax);
                        decimal.TryParse(split[11], out total);
                        order.TaxCost = totalTax;
                        order.Total = total;

                        orderList.Add(order);
                    
                }
            }
            return orderList;
        }
    }
}
