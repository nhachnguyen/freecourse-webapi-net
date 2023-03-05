using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll(string search, double? fromPrice, double? toPrice, string? sortBy, int page);
    }
}
