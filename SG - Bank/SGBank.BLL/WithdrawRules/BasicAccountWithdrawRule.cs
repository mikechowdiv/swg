using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account acct, decimal amt)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (acct.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = "Error: a non-basic account hit the Basic Withdraw Rule. Contact IT";
                return response;
            }

            if (amt >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative!";
                return response;
            }

            if (amt < -500)
            {
                response.Success = false;
                response.Message = "Basic accounts cannot withdraw more than $500!";
                return response;
            }

            if (acct.Balance + 100 < -amt)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit!";
                return response;
            }

            if (acct.Balance < 0)
            {
                acct.Balance -= 10;
            }

            response.Account = acct;
            response.Amount = amt;
            response.Success = true;
            response.OldBalance = acct.Balance;
            acct.Balance += amt;
           
            return response;
        }
    }
}
