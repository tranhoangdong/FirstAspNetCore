using eShopsolution.Data.Enums;

using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;
using eShopSolution.Data.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configuration
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("AppRole"); 

            builder.HasKey(x => x.RoleID); 

            builder.Property(x => x.RoleID).UseIdentityColumn();

            builder.Property(x => x.RoleName).IsRequired(); 

            builder.Property(x => x.Description).IsRequired();

            
        }
    }
}
