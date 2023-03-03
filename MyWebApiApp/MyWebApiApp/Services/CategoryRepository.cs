using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public CategoryVM Add(CategoryModel category)
        {
            var _category = new Categories
            {
                CategoryName = category.CategoryName
            };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryVM
            {
                CategoryId = _category.CategoryId,
                CategoryName = category.CategoryName
            };

        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var Category = _context.Categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            });
            return Category.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var Category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);
            if (Category != null)
            {
                return new CategoryVM
                {
                    CategoryId = Category.CategoryId,
                    CategoryName = Category.CategoryName
                };
            }
            return null;
        }

        //public CategoryVM Update(CategoryVM categoryVM)
        //{
        //    var category = _context.Categories.SingleOrDefault(c => c.CategoryId == categoryVM.CategoryId);
        //    if (category != null)
        //    {
        //        category.CategoryName = categoryVM.CategoryName;
        //        _context.Categories.Update(category);
        //        _context.SaveChanges();
        //        return new CategoryVM { CategoryId = category.CategoryId, CategoryName = category.CategoryName };
        //    }
        //    return null;
        //}

        public void Update(CategoryVM category)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
                _context.Categories.Update(_category);
                _context.SaveChanges();
            }
        }
    }
}
