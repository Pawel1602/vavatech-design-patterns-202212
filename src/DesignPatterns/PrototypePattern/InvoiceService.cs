using System;

namespace PrototypePattern
{
    public class InvoiceService
    {
        public Invoice CreateCopy(Invoice invoice, string newNumber)
        {
            Invoice invoiceCopy = new Invoice(invoice.Number, DateTime.Today, invoice.PaymentType, invoice.Customer);
           
            return invoiceCopy;
        }
    }


}
