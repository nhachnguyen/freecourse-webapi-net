namespace MyWebApiApp.Models
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }  
    }

    public class Product: ProductVM
    {
        public Guid ProductID { get; set; }
    }
}
