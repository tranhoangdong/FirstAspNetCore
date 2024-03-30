
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class CategoryTranslationConfigurations : IEntityTypeConfiguration<CategoryTranslation>
    {
        public void Configure(EntityTypeBuilder<CategoryTranslation> builder)
        {
            builder.ToTable("CategoryTranslation"); 

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Id).UseIdentityColumn();

          
            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SeoDescription).IsRequired().HasMaxLength(500);
            builder.Property(x => x.SeoTitle).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LanguageId).IsRequired().HasMaxLength(10);
            builder.Property(x => x.SeoAlias).IsRequired().HasMaxLength(255);

          
            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Translations)
                   .HasForeignKey(x => x.CategoryId);

         
        }
    }
}
