using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class RequestEFinanceConfiguration : IEntityTypeConfiguration<RequestEFinance>
    {
        public void Configure(EntityTypeBuilder<RequestEFinance> builder)
        {
            builder.ToTable("RequestEFinance");
            builder.Property(p => p.SenderId)
                .HasMaxLength(50);

            builder.Property(p => p.SenderName)
                .HasMaxLength(50);

            builder.Property(p => p.SenderRandomValue)
                .HasMaxLength(100);

            builder.Property(p => p.SenderPassword)
                .HasMaxLength(100);

            builder.Property(p => p.SenderRequestNumber)
                .HasMaxLength(50);

            builder.Property(p => p.PaymentRequestNumber)
                .HasMaxLength(50);

            builder.Property(p => p.AuthorizingMechanism)
                .HasMaxLength(20);

            builder.Property(p => p.CollectionFeesAmount)
                .HasColumnType("DECIMAL(15, 5)");

            builder.Property(p => p.CustomerAuthorizationAmount)
                .HasColumnType("DECIMAL(15, 5)");

            builder.Property(p => p.PaymentRequestTotalAmount)
                .HasColumnType("DECIMAL(15, 5)");
        }
    }
}
