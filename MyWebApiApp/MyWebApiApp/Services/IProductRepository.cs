using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface IProductRepository
    {
        List<ProductModel> GetAll(string search);
    }
}
