using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eShopsolution.Data.EF
{
    public class EShopDbContext : DbContext
    {
        

        public EShopDbContext( DbContextOptions options) : base(options)
        {   
        }
        public virtual DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ID).HasColumnType("int");

            });


        }

    }
}
