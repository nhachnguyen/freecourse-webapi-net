using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions dbContextOptions): base(dbContextOptions) { }

        #region DbSet
        public DbSet<Product> Products { get; set; }
        
        public DbSet<Categories> Categories { get; set; }
        #endregion
    }
}
