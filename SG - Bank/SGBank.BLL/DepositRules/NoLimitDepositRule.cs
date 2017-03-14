using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class NoLimitDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account acct, decimal amt)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if (acct.Type != AccountType.Basic && acct.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: Only basic and premium accounts can deposit with no limit. Contact IT";
                return response;
            }

            if (amt <= 0)
            {
                response.Success = false;
                response.Message = "Deposit amounts must be positive!";
                return response;
            }

            response.Success = true;
            acct.Balance += amt;
            response.Account = acct;
            response.Amount = amt;
            response.OldBalance = acct.Balance;
            return response;
        }      
    }
}
