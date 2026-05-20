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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Model).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Brand).IsRequired().HasMaxLength(100);
            builder.Property(c => c.PlateNumber).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.PlateNumber).IsUnique();
            builder.Property(c => c.DailyPrice).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(c => c.EngineCC).IsRequired();
            builder.Property(c => c.SeatCount).IsRequired();

            builder.HasOne(c => c.Company)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
