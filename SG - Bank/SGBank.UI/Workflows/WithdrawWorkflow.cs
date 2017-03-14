using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models.Responses;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            AccountManager acctmgtr = AccountManagerFactory.Create();

            Console.WriteLine("enter an account number: ");
            string acctNum = Console.ReadLine();

            Console.WriteLine("enter the amount: ");
            decimal amt = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = acctmgtr.Withdraw(acctNum, amt);

            if (response.Success)
            {
                Console.WriteLine("Action completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount involved: {response.Amount:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("an error occurred");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
