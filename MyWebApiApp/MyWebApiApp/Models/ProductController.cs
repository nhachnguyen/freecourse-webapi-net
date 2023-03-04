using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Services;

namespace MyWebApiApp.Models
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
        public IActionResult GetAllProduct(string search)
        {
            try
            {
                var result = _productRepository.GetAll(search);
                return Ok(result);
            }
            catch
            {
                return BadRequest("We cannot get the product.");
            }
        }
    }
}
