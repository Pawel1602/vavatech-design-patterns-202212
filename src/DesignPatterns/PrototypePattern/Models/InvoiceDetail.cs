using System;

namespace PrototypePattern
{
    public class InvoiceDetail : ICloneable
    {
        public InvoiceDetail(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
            Amount = product.UnitPrice;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxRatio { get; set; }

        //public object Clone()
        //{
        //    return Copy();
        //}

        //private InvoiceDetail Copy()
        //{
        //    InvoiceDetail copyInvoiceDetail = new InvoiceDetail(this.Product, this.Quantity);

        //    copyInvoiceDetail.Amount = this.Amount;

        //    return copyInvoiceDetail;
        //}

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"- {Product} {Quantity} {Amount:C2}";
        }
    }


}
