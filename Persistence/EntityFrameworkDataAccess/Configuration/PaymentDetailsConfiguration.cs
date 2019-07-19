using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class PaymentDetailsConfiguration : IEntityTypeConfiguration<PaymentDetails>
    {
        public void Configure(EntityTypeBuilder<PaymentDetails> builder)
        {
            builder.ToTable("PaymentDetails");
            builder.Property(p => p.Code)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Notes)
                .HasMaxLength(500);

            //builder.Property(p => p.InsertedDate)
            //    .HasDefaultValue(DateTime.Now);

            builder.Property(p => p.Price).HasColumnType("DECIMAL(15, 5)");
        }
    }
}
