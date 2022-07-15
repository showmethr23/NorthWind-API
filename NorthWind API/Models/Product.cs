namespace NorthWind_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
    }
}
