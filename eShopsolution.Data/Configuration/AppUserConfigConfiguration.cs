using eShopSolution.Data.Emtyties;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUser"); 

            builder.HasKey(x => x.UserID); 

            builder.Property(x => x.UserID).UseIdentityColumn(); 

            builder.Property(x => x.Username).IsRequired(); 

            builder.Property(x => x.Password).IsRequired(); 

            builder.Property(x => x.Email).IsRequired(); 

            builder.Property(x => x.FullName).IsRequired(); 

           
        }
    }
}
