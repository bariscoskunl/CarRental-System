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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Content).IsRequired().HasMaxLength(500);
            builder.Property(c => c.Rating).IsRequired();

            builder.HasOne(c => c.Car)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Company)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Customer)
                .WithMany(c => c.PostedComments)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
