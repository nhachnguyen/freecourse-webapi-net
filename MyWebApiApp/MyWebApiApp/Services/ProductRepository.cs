using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<ProductModel> GetAll(string search)
        {
            var allProducts = _context.Products.AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(prd => prd.ProductName.Contains(search));
            }                    

            var result = allProducts.Select(prd => new ProductModel
            {
                ProductId = prd.ProductId,
                ProductName = prd.ProductName,
                UnitPrice = prd.UnitPrice,
                CategoryName = prd.Categories.CategoryName
            });
            return result.ToList();
        }
    }
}
