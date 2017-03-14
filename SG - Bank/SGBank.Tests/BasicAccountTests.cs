using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;

namespace SGBank.Tests
{ 
        [TestFixture]
       public class BasicAccountTests
        {

            [Test]
            [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
            [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
            [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]

            public void FreeAccountDepositRuleTest(string acctNum, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
            {
                IDeposit RuleTest = new NoLimitDepositRule();
                Account acct = new Account()
                {
                    AccountNumber = acctNum,
                    Name = name,
                    Balance = balance,
                    Type = accountType
                };

                AccountDepositResponse response = RuleTest.Deposit(acct, amount);
                bool actual = response.Success;

                Assert.AreEqual(expectedResult, actual);

            }

        [Test]
        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000,1500, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false)]
        [TestCase("33333", "Basic Account", 150, AccountType.Basic, -50, 100, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]


        public void BasicAccountWithdrawRuleTest(string acctNum, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
           IWithdraw RuleTest = new BasicAccountWithdrawRule();
            Account acct = new Account()
            {
                AccountNumber = acctNum,
                Name = name,
                Balance = balance,
                Type = accountType
            };

            AccountWithdrawResponse response = RuleTest.Withdraw(acct, amount);
            bool actual = response.Success;

            Assert.AreEqual(expectedResult, actual);

        }



    }
}

