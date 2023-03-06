using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _context;
        public CategoriesController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categoriesList = _context.Categories.ToList();
            return Ok(categoriesList);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault<Categories>(c => c.CategoryId == id);
            if(category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Categories>> CreateNewCategory(CategoryModel categoryModel)
        {
            try
            {
                var category = new Categories()
                {
                    CategoryName = categoryModel.CategoryName
                };
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategoryById(int id, CategoryModel categoryModel)
        {
            var category = _context.Categories.SingleOrDefault<Categories>(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            category.CategoryName = categoryModel.CategoryName;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoryById(int id)
        {
            var category = _context.Categories.SingleOrDefault<Categories>(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
