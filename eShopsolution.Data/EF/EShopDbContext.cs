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
            
          
           
            
        }

        public DbSet<Product> Products { get; set; }
      

      



    }
}
