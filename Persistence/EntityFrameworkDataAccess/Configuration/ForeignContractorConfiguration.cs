using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class ForeignContractorConfiguration : IEntityTypeConfiguration<ForeignContractor>
    {
        public void Configure(EntityTypeBuilder<ForeignContractor> builder)
        {
            builder.Property(p => p.ContractorName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ContractorActivity)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ContractorJobName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AddressCity)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AddressDistrict)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AddressStreet)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AddressBuilding)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Salary)
                .HasColumnType("DECIMAL(15, 5)");
        }
    }
}
