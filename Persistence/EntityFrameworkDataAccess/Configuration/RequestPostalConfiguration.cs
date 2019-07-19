using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class RequestPostalConfiguration : IEntityTypeConfiguration<RequestPostal>
    {
        public void Configure(EntityTypeBuilder<RequestPostal> builder)
        {
            builder.ToTable("RequestPostal");
            builder.Property(p => p.ErrorCode)
                .HasMaxLength(10)
                 .IsRequired();

            builder.Property(p => p.ItemCode)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Message)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
