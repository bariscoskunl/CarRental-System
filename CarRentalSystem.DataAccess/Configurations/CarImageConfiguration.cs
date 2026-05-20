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
    public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ImageUrl).IsRequired().HasMaxLength(2000);
            builder.Property(c => c.IsCoverImage).IsRequired().HasDefaultValue(false);

            builder.HasOne(c => c.Car)
                .WithMany(c => c.Images)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
