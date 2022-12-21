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

            Executive executive = new Executive();

            CEO ceo = new CEO();
            ceo.Successor = executive;

            Director director = new Director();
            director.Successor = ceo; 

            ProductManager manager = new ProductManager();
            manager.Successor = director;

            // Act
            manager.ProcessRequest(purchase);            

            // Assert
            Assert.AreSame(manager, purchase.ApprovedBy);
        }

        [TestMethod]
        public void ProcessRequest_Amount8000_ShouldApprovedByCEO()
        {
            // Arrange
            Purchase purchase = new Purchase(8_000, "Book Design Pattern in C#");

            Executive executive = new Executive();

            CEO ceo = new CEO();
            ceo.Successor = executive;

            Director director = new Director();
            director.Successor = ceo;

            ProductManager manager = new ProductManager();
            manager.Successor = director;

            // Act
            manager.ProcessRequest(purchase);

            // Assert
            Assert.AreSame(ceo, purchase.ApprovedBy);
        }

        [TestMethod]
        public void ProcessRequest_Amount100_000_ShouldApprovedByExecutive()
        {
            // Arrange
            Purchase purchase = new Purchase(100_000, "Car");

            Executive executive = new Executive();

            CEO ceo = new CEO();
            ceo.Successor = executive;

            Director director = new Director();
            director.Successor = ceo;

            ProductManager manager = new ProductManager();
            manager.Successor = director;

            // Act
            manager.ProcessRequest(purchase);

            // Assert
            Assert.AreSame(executive, purchase.ApprovedBy);
        }

    }
}
