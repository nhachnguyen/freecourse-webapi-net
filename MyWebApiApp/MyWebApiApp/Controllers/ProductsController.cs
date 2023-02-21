using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = products.SingleOrDefault<Product>(p => p.ProductID.ToString() == id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product()
            {
                ProductID = Guid.NewGuid(),
                ProductName = productVM.ProductName,
                UnitPrice = productVM.UnitPrice
            };
            products.Add(product);
            return Ok(new
            {
                Success = true,
                Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, ProductVM productVM)
        {
            try
            {
                var product = products.SingleOrDefault<Product>(p => p.ProductID.ToString() == id);
                if (product == null)
                {
                    return NotFound();
                }

                productVM.ProductName = product.ProductName;
                productVM.UnitPrice = product.UnitPrice;

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = products.SingleOrDefault<Product>(p => p.ProductID.ToString() == id);
                if (product == null)
                {
                    return NotFound();
                }

                products.Remove(product);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
