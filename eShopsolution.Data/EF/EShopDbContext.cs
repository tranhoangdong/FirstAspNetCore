using eShopSolution.Data.Configuration;
using eShopSolution.Data.Configurations;
using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopsolution.Data.EF
{
    public class EShopDbContext : IdentityDbContext
    {


        public EShopDbContext( DbContextOptions options) : base(options)
        {   
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        

        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }


      



    }
}
