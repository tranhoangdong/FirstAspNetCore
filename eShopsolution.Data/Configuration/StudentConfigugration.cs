using eShopSolution.Data.Emtyties;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Configuration
{
    public class StudentConfigugration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.StudentID);
            builder.Property(x => x.StudentID).UseIdentityColumn();


            builder.Property(x => x.StudentName);

            builder.Property(x => x.Mark);

            builder.Property(x => x.City);



        }
    }
}