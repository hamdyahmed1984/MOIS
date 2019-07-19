using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class RequestFawryConfiguration : IEntityTypeConfiguration<RequestFawry>
    {
        public void Configure(EntityTypeBuilder<RequestFawry> builder)
        {
            builder.ToTable("RequestFawry");
            builder.Property(p => p.FawryRefNo)
                .HasMaxLength(20);

            builder.Property(p => p.FawryPaymentMethod)
                .HasMaxLength(20);

            builder.Property(p => p.MessageSignature)
                .HasMaxLength(64);

            builder.Property(p => p.Notes)
                .HasMaxLength(500);


            builder.Property(p => p.OrderAmount).HasColumnType("DECIMAL(15, 5)");
        }
    }
}
