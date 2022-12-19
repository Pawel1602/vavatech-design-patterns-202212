using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PrototypePattern.UnitTests
{
    // PM> Install-Package FluentAssertions

    [TestClass]
    public class InvoiceServiceTests
    {
        [TestMethod]
        public void CreateCopy_Invoice_ShouldBeCopyOfInvoice()
        {
            // Arrange
            InvoiceService invoiceService = new InvoiceService();
            Invoice invoice = CreateInvoice();

            // Act
            var copyInvoice = invoiceService.CreateCopy(invoice, "FA 2");

            // Assert
            copyInvoice.Should().NotBeSameAs(invoice);

            copyInvoice.Number.Should().NotBe(invoice.Number);
            copyInvoice.CreateDate.Should().NotBe(invoice.CreateDate);


            copyInvoice.Should().BeEquivalentTo(invoice,
                options => options
                .Excluding(i=>i.CreateDate)
                .Excluding(i=>i.Number));

            var detailsReferenceEquals = invoice.Details.Zip(copyInvoice.Details, (original, copy) => ReferenceEquals(original, copy));

            var productsReferenceEquals = invoice.Details.Zip(copyInvoice.Details, (original, copy) => ReferenceEquals(original.Product, copy.Product));

            detailsReferenceEquals.All(x => x).Should().BeFalse();

            productsReferenceEquals.All(x => x).Should().BeTrue();


        }

        private static Invoice CreateInvoice()
        {
            Customer customer = new Customer("John", "Smith");
            Product product1 = new Product("Keyboard", 250);
            Product product2 = new Product("Mouse", 150);

            Invoice invoice = new Invoice("FA 1", DateTime.Parse("2022-03-01"), PaymentType.Transfer, customer);
            invoice.Details.Add(new InvoiceDetail(product1));
            invoice.Details.Add(new InvoiceDetail(product2, 3));

            invoice.DueDate = invoice.CreateDate.AddDays(14);

            return invoice;
        }
    }
}
