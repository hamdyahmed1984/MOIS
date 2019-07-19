using Domain.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class RegulationConfiguration : IEntityTypeConfiguration<Regulation>
    {
        public void Configure(EntityTypeBuilder<Regulation> builder)
        {
            builder.HasKey(t => new { t.DocumentTypeId, t.JobTypeNIDId });
        }
    }
}
