using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.FlatNumber)
                 .IsRequired();

            builder.Property(p => p.FloorNumber)
                .IsRequired();

            builder.Property(p => p.BuildingNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.StreetName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.DistrictName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
