namespace BuilderPattern
{
    public class ProductReportDetail
    {
        public ProductReportDetail(Product product, int quantity, decimal totalAmount)
        {
            Product = product;
            Quantity = quantity;
            TotalAmount = totalAmount;
        }

        public Product Product { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
    }




}