namespace PrototypePattern
{
    public class Product
    {
        public Product(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
