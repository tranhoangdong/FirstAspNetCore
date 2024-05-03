using eShopSolution.Data.Configuration;
using eShopSolution.Data.Configurations;
using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolution.Data.EF
{
    public class EShopDbContext : DbContext
    {


        public EShopDbContext( DbContextOptions options) : base(options)
        {   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure using Fluent API
           // modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductInCategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        //public DbSet<AppConfig> AppConfigs { get; set; }

        //public DbSet<Cart> Carts { get; set; }

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }


        //public DbSet<Contact> Contacts { get; set; }

        //public DbSet<Language> Languages { get; set; }

        //public DbSet<Order> Orders { get; set; }

        //public DbSet<OrderDetail> OrderDetails { get; set; }
        //public DbSet<ProductTranslation> ProductTranslations { get; set; }

        //public DbSet<Promotion> Promotions { get; set; }

        //public DbSet<Transaction> Transactions { get; set; }



    }
}
