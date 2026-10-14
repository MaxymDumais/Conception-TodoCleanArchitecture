using CleanTodo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Infrastructure.Data.Configurations
{
   public class ShipConfiguration : IEntityTypeConfiguration<Ship>
   {
      public void Configure(EntityTypeBuilder<Ship> builder)
      {
         builder.HasKey(s => s.Id);

         builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

         builder.Property(s => s.GoldCargo)
            .IsRequired();

         builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(50);

         builder.Property(s => s.CrewSize)
            .IsRequired();

         builder.Property(s => s.Status)
            .IsRequired();

         builder.Property(s => s.CreatedBy)
            .IsRequired();

         builder.Property(s => s.CreatedAt)
            .IsRequired();

         builder.Property(s => s.LastModified)
            .IsRequired();
      }
   }
}
