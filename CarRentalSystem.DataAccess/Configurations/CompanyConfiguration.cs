using CarRentalSystem.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Surname).IsRequired().HasMaxLength(100);
            builder.Property(c => c.CompanyName).IsRequired().HasMaxLength(200);
            builder.Property(c => c.TaxNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.PersonelEmail).IsRequired().HasMaxLength(200);
            builder.Property(c => c.CompanyEmail).IsRequired().HasMaxLength(200);
            builder.Property(c => c.CompanyPhone).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(300);
            builder.Property(c => c.City).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Country).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Website).HasMaxLength(300);

        }
    }
}
