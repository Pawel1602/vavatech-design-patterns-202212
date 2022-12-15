using CommandPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommandPattern.UnitTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void History()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();

            // Act
            bankAccount.Deposit(100);
            bankAccount.Withdraw(100);
            bankAccount.Deposit(200);
            bankAccount.Deposit(100);
            bankAccount.Withdraw(50);

            var result = bankAccount.GetBalance();

            // Assert
            Assert.AreEqual(250, result);
        }

        [TestMethod]
        public void Withdraw_OverdraftLimit_ShouldThrowsApplicationException()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount();

            bankAccount.Deposit(100);

            // Act
            Action act = () => bankAccount.Withdraw(1000);

            // Assert
            Assert.ThrowsException<ApplicationException>(act);
        }
    }
}
