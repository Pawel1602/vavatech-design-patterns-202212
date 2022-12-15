using ChainOfResponsibilityPattern.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace ChainOfResponsibilityPattern.UnitTests.UnitTests
{
    [TestClass]
    public class ProcessRequestTests
    {
        private Approver manager;
        private Approver director;
        private Approver ceo;

        [TestInitialize]
        public void Init()
        {
            manager = new ProductManager();
            director = new Director();
            ceo = new CEO();        
        }

        [TestMethod]
        public void ProcessRequest_AmountBelow999_ShouldApprovedByManager()
        {
            // Arrange
            Purchase purchase = new Purchase(999, "Book Design Pattern in C#");

            // Act
            if (purchase.Amount < 1000)
            {
                Trace.WriteLine("ProductManager approved request");
                purchase.ApprovedBy = manager;
            }
            else if (purchase.Amount < 5000)
            {
                Trace.WriteLine("Director approved request");
                purchase.ApprovedBy = director;
            }
            else if (purchase.Amount < 10_000)
            {
                Trace.WriteLine("CEO approved request");
                purchase.ApprovedBy = ceo;
            }
            else
            {
                Trace.WriteLine("Request requires an executive meeting!");
            }

            // Assert
            Assert.AreSame(manager, purchase.ApprovedBy);
        }
    }
}
