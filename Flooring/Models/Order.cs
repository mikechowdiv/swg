using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class Order
   {
    //   private static int numOrder = 0;
        public DateTime Date { get; set; }
        public int OrderNum { get; set; }
        public string CustName { get; set; }
        public  StateTax STax { get; set; }
        public Product Product { get; set; }
        public decimal Area { get; set; }
        public decimal MatCost { get; set; }
        public decimal LaborCost { get; set; }
        public decimal TaxCost { get; set; }
        public decimal Total { get; set; }

        string path = @"E:\workspace\SG-works\week5 project\Flooring2.7\order.txt";

        public Order()
       {
           
       }

       public Order(string cust, Product prod, StateTax state, decimal area, DateTime date)
       {
           CustName = cust;
           this.Area = area;
           STax = state;
           this.Product = prod;
           this.Date = date;
           OrderNum = GetOrderNum();
           MatCost = Area * prod.CostSF;
           LaborCost = Area * LaborCost;
           TaxCost = (state.TaxRate / 100) * (MatCost + LaborCost);
           Total = MatCost + LaborCost + TaxCost;
       }

        private int GetOrderNum()
        {
            string fromFile = File.ReadAllText(path);
            int num;
            int.TryParse(fromFile, out num);
            saveOrderNum(num + 1);
            return num;
        }

        private void saveOrderNum(int newNum)
        {
            File.WriteAllText(path, newNum.ToString());
        }

        //displaying orders from file
       public override string ToString()
       {
           string newString =
           ("Order Number: " + OrderNum +
           "\nOrder Date: " + Date +
           "\nProduct: " + Product.ProductType +
           "\nArea: " + Area +
           "\nState: " + STax.StateAbb +
           "\nCost per sqFt: " + Product.CostSF +
           "\nLabor per sqFt: " + Product.LaborSF +
           "\nTax: " + TaxCost +
            "\nCustomer Name: " + CustName +
            "\nTotal Cost: $" + Total
           );
           return newString;
       }

       public string ToStringFile()
       {
           string newStr =
           (
               OrderNum + "," + 
               CustName + "," + 
               STax.StateAbb + "," + 
               STax.TaxRate + "," +
               Product.ProductType + "," + 
               Area + "," + 
               Product.CostSF + "," + 
               Product.LaborSF + "," +
               MatCost + "," + 
               LaborCost + "," + 
               TaxCost + "," + 
               Total);
           return newStr;
       }
    }

}
