using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        private static int PAGE_SIZE { get; set; } = 5;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public List<ProductModel> GetAll(string search, double? fromPrice, double? toPrice, string? sortBy, int page)
        {
            var allProducts = _context.Products.Include(prod => prod.Categories).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(prd => prd.ProductName.Contains(search));
            }

            if (fromPrice.HasValue)
            {
                allProducts = allProducts.Where(prd => prd.UnitPrice >= fromPrice);
            }

            if (toPrice.HasValue)
            {
                allProducts = allProducts.Where(prd => prd.UnitPrice <= toPrice);
            }
            #endregion

            #region Sorting
            // Default sort by product name ASC            
            allProducts = allProducts.OrderBy(prd => prd.ProductName);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "prodName_desc":
                        allProducts = allProducts.OrderByDescending(prd => prd.ProductName);
                        break;
                    case "unitPrice_asc":
                        allProducts = allProducts.OrderBy(prd => prd.UnitPrice);
                        break;
                    case "unitPrice_desc":
                        allProducts = allProducts.OrderByDescending(prd => prd.UnitPrice);
                        break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProducts.Select(prd => new ProductModel
            //{
            //    ProductId = prd.ProductId,
            //    ProductName = prd.ProductName,
            //    UnitPrice = prd.UnitPrice,
            //    CategoryName = prd.Categories.CategoryName
            //});
            //return result.ToList();

            var result = PaginatedList<Data.Product>.Create(allProducts, page, PAGE_SIZE);

            return result.Select(prd => new ProductModel
            {
                ProductId = prd.ProductId,
                ProductName = prd.ProductName,
                UnitPrice = prd.UnitPrice,
                CategoryName = prd.Categories?.CategoryName
            }).ToList();
        }
    }
}
