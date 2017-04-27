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
    public class TaxRepo : IStateRepo
    {
        public StateTax GetTaxes(string stateAbb)
        {
            StateTax tax = null;
            List<StateTax> taxes = GetAllTaxes();
            foreach (StateTax items in taxes)
            {
                if (items.StateAbb == stateAbb)
                {
                    tax = items;
                }
            }
            return tax;
        }

        public List<StateTax> GetAllTaxes()
        {
            List<StateTax> allTaxes = new List<StateTax>();
            bool exists = File.Exists(getPath());
            if (exists)
            {
                string[] split;
                string taxStr;
                using (var stream = File.OpenRead(getPath()))
                using (var reader = new StreamReader(stream))
                {
                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        taxStr = reader.ReadLine();
                        split = taxStr.Split(',');
                        string state = split[0];
                        decimal tax;
                        decimal.TryParse(split[2], out tax);
                        StateTax st = new StateTax(state, tax);
                        allTaxes.Add(st);
                    }
                }
            }
            return allTaxes;
        }

        private string getPath()
        {
            return (@"E:\workspace\SG-works\week5 project\Flooring2.7\Taxes.txt");
        }
    }
}
