using Microsoft.EntityFrameworkCore;

namespace CROUD_Products_WebApi.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            // تعیین ارتباطات بین مدل‌ها
            
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasMany(i => i.Images)
                .WithOne(p => p.Products)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Category>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId);

            /*
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Products)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.Products);
            */

            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18, 2)"); // اینجا مقدار precision و scale به عنوان مثال آورده شده است، شما باید آنها را به تناسب نیاز خود تنظیم کنید.


            base.OnModelCreating(modelBuilder);

            
            // تعریف کلیدها و محدودیت‌ها دیگر

            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Image>()
                .HasKey(i => i.Id);

            // ویژگی‌های دیگر مانند حذف خودکار، به‌روزرسانی خودکار و ...

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

        }
    }
}
