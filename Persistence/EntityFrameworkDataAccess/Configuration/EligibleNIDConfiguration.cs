using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class EligibleNIDConfiguration : IEntityTypeConfiguration<EligibleNID>
    {
        public void Configure(EntityTypeBuilder<EligibleNID> builder)
        {
            builder.ToTable("EligibleNID");
            builder.Property(p => p.HashedNID)
                .HasMaxLength(64)
                .IsUnicode()
                .IsRequired();
        }
    }
}
