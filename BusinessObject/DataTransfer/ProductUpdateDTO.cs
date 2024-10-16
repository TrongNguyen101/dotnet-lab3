namespace BusinessObject.DataTransfer
{
    public class ProductUpdateDTO
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}