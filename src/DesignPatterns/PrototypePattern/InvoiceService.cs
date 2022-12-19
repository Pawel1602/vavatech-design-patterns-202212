using System;

namespace PrototypePattern
{
    public class InvoiceService
    {
        public Invoice CreateCopy(Invoice invoice, string newNumber)
        {
            Invoice invoiceCopy = (Invoice) invoice.Clone();
            
            invoiceCopy.Number = newNumber;

            return invoiceCopy;
        }
    }


}
