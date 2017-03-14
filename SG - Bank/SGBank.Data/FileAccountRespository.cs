using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;

namespace SGBank.Data
{
    public class FileAccountRespository : IAccountRepository
    {
        List<Account> accounts = new List<Account>();

        private void LoadData()
        {
            using (StreamReader sr = new StreamReader(Setting.FilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account acct1 = new Account();
                    string[] columns = line.Split(',');
                    acct1.AccountNumber = columns[0];
                    acct1.Name = columns[1];
                    acct1.Balance = decimal.Parse(columns[2]);
                    switch (columns[3])
                    {
                        case "F":
                            acct1.Type = AccountType.Free;
                            break;
                        case "B":
                            acct1.Type = AccountType.Basic;
                            break;
                        case "P":
                            acct1.Type = AccountType.Premium;
                            break;
                                           
                    }
                    accounts.Add(acct1);
                }             
            }
        }

        public Account LoadAccount(string AccountNumber)
        {
            LoadData();
            foreach (var items in accounts)
            {
                if (AccountNumber == items.AccountNumber)
                {
                    return items;
                }
            }
            return null;
        }

        private void WriteFile()
        {
            using (StreamWriter sw = new StreamWriter(Setting.FilePath,false))
            {
                sw.Write("AccountNumber,Name,Balance,Type");
                string acctString;
                foreach (Account acct in accounts)
                {
                    switch (acct.Type)
                    {
                            case AccountType.Free:
                            acctString = "F";
                            break;
                            case  AccountType.Basic:
                            acctString = "B";
                            break;
                            case  AccountType.Premium:
                            acctString = "p";
                            break;
                        default:
                            throw new Exception();

                    }
                    sw.WriteLine();
                    sw.Write($"{acct.AccountNumber},{acct.Name},{acct.Balance.ToString()},{acctString}");
                }
            }
        }


        public void SaveAccount(Account acct)
        {
            for (int i = 0; i < accounts.Count(); i++)
            {
                if (acct.AccountNumber == accounts[i].AccountNumber)
                {
                    accounts[i].Balance = acct.Balance;
                }
            }       
        }
    }
}
