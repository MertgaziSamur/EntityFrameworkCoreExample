using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Udemy.EfCore.Data.Entities;

namespace Udemy.EfCore.Data.Contexts
{
    public class EfContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleHistory> SaleHistories { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=EfCore; integrated security=true;");

        }
        //FluentAPI
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // **ONE-TO-MANY**
            //modelBuilder.Entity<Product>().HasMany(x => x.SaleHistories).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<SaleHistory>().HasOne(x => x.Product).WithMany(x => x.SaleHistories)
                .HasForeignKey(x => x.ProductId);

            // **ONE-TO-ONE**
            modelBuilder.Entity<Product>().HasOne(x => x.ProductDetail).WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.ProductId);

            // **MANY-TO-MANY
            modelBuilder.Entity<Product>().HasMany(x => x.ProductCategories).WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Category>().HasMany(x => x.ProductCategories).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });

            //modelBuilder.Entity<Category>().ToTable(name: "Categories", schema: "dbo");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("product_name");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Product>().Property(x => x.CreatedTime).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnName("product_price");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("product_id");
            base.OnModelCreating(modelBuilder);
        }
    }
}
