using DubaiPhoneClone.Models;
using Microsoft.EntityFrameworkCore;


namespace DubaiPhoneClone.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Brand>? Brands { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Coupon>? Coupons { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderCoupon>? OrderCoupons { get; set; }
        public DbSet<OrderItem>? OrderItems { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductImage>? ProductImages { get; set; }
        public DbSet<WishlistItem>? WishlistItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DubaiPhone;Integrated Security=True;TrustServerCertificate=True");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specify unique constraint for UserName
            modelBuilder.Entity<User>()
                .HasIndex(c => c.UserName)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(c => c.Email)
                .IsUnique();

        }
    }
}
