using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions dbContextOptions): base(dbContextOptions) { }

        #region DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }        
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(o => o.OrderId);
                e.Property(o => o.OrderDate).HasDefaultValueSql("getutcdate()");
                e.Property(o => o.DeliveryDate).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new { e.ProductId, e.OrderId });
                entity.HasOne(e => e.Order)
                      .WithMany(e => e.OrderDetails)
                      .HasForeignKey(e => e.OrderId)
                      .HasConstraintName("PK_OrderDetail_Order");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserName).IsUnique();
                entity.Property(e => e.FullName).HasMaxLength(150);
                entity.Property(e => e.Email).HasMaxLength(150);
            });
        }
    }
}
