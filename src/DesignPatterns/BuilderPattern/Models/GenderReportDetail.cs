namespace BuilderPattern
{
    public class GenderReportDetail
    {
        public GenderReportDetail(Gender gender, int quantity, decimal totalAmount)
        {
            Gender = gender;
            Quantity = quantity;
            TotalAmount = totalAmount;
        }

        public Gender Gender { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
    }




}