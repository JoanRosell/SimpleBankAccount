using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: add tests for negative amounts
namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void AccountTest()
        {
            Account acc = new Account();
            Assert.IsNotNull(acc);
            Assert.AreEqual(0m, acc.Balance);
        }

        [TestMethod()]
        public void AccountParameterizedTest()
        {
            Account acc = new Account(10);
            Assert.IsNotNull(acc);
            Assert.AreEqual(10m, acc.Balance);
        }

        [TestMethod()]
        public void AccountNegativeCtorTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new Account(-1));
        }


        [TestMethod()]
        public void WithdrawTest()
        {
            Account acc = new Account(10);
            Assert.AreEqual(5m, acc.Withdraw(5m));
            Assert.AreEqual(5m, acc.Balance);
        }

        [TestMethod()]
        public void WithdrawExceptionTest()
        {
            Account acc = new Account(10);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => acc.Withdraw(20m));
            Console.WriteLine(ex.Message);
            Assert.AreEqual(10m, acc.Balance);
        }

        [TestMethod()]
        public void WithdrawNegativeAmountTest()
        {
            Account acc = new Account(10);
            var ex = Assert.ThrowsException<InvalidOperationException>(() => acc.Withdraw(-20m));
            Console.WriteLine(ex.Message);
            Assert.AreEqual(10m, acc.Balance);
        }

        [TestMethod()]
        public void DepositTest()
        {
            Account acc = new Account();
            acc.Deposit(10.0m);
            Assert.AreEqual(10, acc.Balance);
        }

        [TestMethod()]
        public void DepositOverflowTest()
        {
            Account acc = new Account(decimal.MaxValue);
            Assert.ThrowsException<OverflowException>(() => acc.Deposit(1.0m));
        }

        [TestMethod()]
        public void DepositNegativeAmountTest()
        {
            Account acc = new Account(10m);
            Assert.ThrowsException<InvalidOperationException>(() => acc.Deposit(-1.0m));
            Assert.AreEqual(10, acc.Balance);
        }
    }
}