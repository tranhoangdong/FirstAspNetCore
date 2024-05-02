using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Price);

            builder.Property(x => x.ProductName);

            builder.Property(x => x.OriginalPrice);

            builder.Property(x => x.Stock).HasDefaultValue(0);

            builder.Property(x => x.ViewCount).HasDefaultValue(0);

            builder.Property(x => x.DateCreated);

            builder.Property(x => x.IsFeatured);

            builder.Property(x => x.Description).HasColumnName("Descreption");

            builder.Property(x => x.CategoryId);

            builder.HasOne<Category>(s => s.Category)
                   .WithMany(g => g.Products)
                   .HasForeignKey(s => s.CategoryId);

        }
    }
}