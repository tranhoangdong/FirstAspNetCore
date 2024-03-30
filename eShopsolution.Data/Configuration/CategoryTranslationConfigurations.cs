using eShopsolution.Data.Enums;

using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configurations
{
    public class CategoryTranslationConfigurations : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslation");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

         
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Translations)
                   .HasForeignKey(x => x.CategoryId);

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
        }
    }
}
