using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Constraints;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models.Interfaces;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [Test]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250,false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string acctNum, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit RuleTest = new FreeAccountDepositRule();
            Account acct = new Account()
            {
                AccountNumber = acctNum,
                Name = name,
                Balance = balance,
                Type = accountType
            };
            AccountDepositResponse response = RuleTest.Deposit(acct, amount);
            bool actual = response.Success;

            Assert.AreEqual(expectedResult,actual);

        }

        [Test]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]

        public void FreeAccountWithdrawRuleTest(string acctNum, string name, decimal balance, AccountType accountType,
            decimal amount, bool expectedResult)
        {
            IWithdraw RuleTest = new FreeAccountWithdrawRule();
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
