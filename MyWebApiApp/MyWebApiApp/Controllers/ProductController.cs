using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Services;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProduct(string? search, double? fromPrice, double? toPrice, string? sortBy, int page = 1)
        {
            try
            {
                var result = _productRepository.GetAll(search, fromPrice, toPrice, sortBy, page);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We cannot get the product.");
            }
        }
    }
}
