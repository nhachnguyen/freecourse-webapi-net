namespace MyWebApiApp.Models
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
    }

    public class Product : ProductVM
    {
        public Guid ProductId { get; set; }
    }

    public class ProductModel
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public double? UnitPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
