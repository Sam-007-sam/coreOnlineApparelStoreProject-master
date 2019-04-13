using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApparelStoreUserPortal.Models
{
    public partial class OnlineApparelStoreDbContext : DbContext
    {
        public OnlineApparelStoreDbContext()
        {
        }

        public OnlineApparelStoreDbContext(DbContextOptions<OnlineApparelStoreDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<FeedBacks> FeedBacks { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=TRD-502; Database=OnlineApparelStoreDb; Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.HasKey(e => e.AdminId);
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.Property(e => e.BrandName).IsRequired();
            });

            modelBuilder.Entity<Carts>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.ProductId });

                entity.HasIndex(e => e.CustomerId)
                    .IsUnique();

                entity.HasIndex(e => e.ProductId);

                entity.HasOne(d => d.Customer)
                    .WithOne(p => p.Carts)
                    .HasForeignKey<Carts>(d => d.CustomerId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName).IsRequired();
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
            });

            modelBuilder.Entity<FeedBacks>(entity =>
            {
                entity.HasKey(e => e.FeedBackId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.FeedBacks)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<OrderProducts>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("orderProducts");

                entity.HasIndex(e => e.ProductId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.HasIndex(e => e.BrandId);

                entity.HasIndex(e => e.CategoryId);

                entity.HasIndex(e => e.VendorId);

                entity.Property(e => e.ProductName).IsRequired();

                entity.Property(e => e.ProductSize).IsRequired();

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId);
            });

            modelBuilder.Entity<Vendors>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.Property(e => e.VendorEmail).IsRequired();

                entity.Property(e => e.VendorName).IsRequired();
            });
        }
    }
}
