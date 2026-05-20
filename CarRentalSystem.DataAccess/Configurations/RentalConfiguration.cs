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
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.TotalPrice).HasColumnType("decimal(18,2)");
            builder.Property(r => r.ExtraCharges).HasColumnType("decimal(18,2)");

            builder.HasOne(r => r.Car)
                .WithMany(r => r.Rentals)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.Customer)
                .WithMany(r => r.Rentals)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.PickupBranch)
                .WithMany()
                .HasForeignKey(r => r.PickupBranchId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(r => r.ReturnBranch)
                .WithMany()
                .HasForeignKey(r => r.ReturnBranchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
