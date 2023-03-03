using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> categories = new List<CategoryVM>
        {
            new CategoryVM{CategoryId =1, CategoryName="Tivi"},
            new CategoryVM{CategoryId =2, CategoryName="Refrigerator"},
            new CategoryVM{CategoryId =3, CategoryName="Air conditioner"},
            new CategoryVM{CategoryId =4, CategoryName="Washing machine "}
        };

        public CategoryVM Add(CategoryModel category)
        {
            var _category = new CategoryVM
            {
                CategoryId = categories.Max(c => c.CategoryId) + 1,
                CategoryName = category.CategoryName
            };
            categories.Add(_category);
            return _category;
        }

        public void Delete(int id)
        {
            var category = categories.SingleOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                categories.Remove(category);
            }
        }

        public List<CategoryVM> GetAll()
        {
            return categories;
        }

        public CategoryVM GetById(int id)
        {
            return categories.SingleOrDefault(c => c.CategoryId == id);
        }

        public void Update(CategoryVM category)
        {
            var _category = categories.SingleOrDefault(c => c.CategoryId == category.CategoryId);
            if (_category != null)
            {
                _category.CategoryName = category.CategoryName;
            }
        }
    }
}
