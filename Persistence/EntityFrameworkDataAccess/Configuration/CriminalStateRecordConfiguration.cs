using Domain.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class CriminalStateRecordConfiguration : IEntityTypeConfiguration<CriminalStateRecord>
    {
        public void Configure(EntityTypeBuilder<CriminalStateRecord> builder)
        {
            builder.Property(p => p.IssueDestination)
                .HasMaxLength(100)
                .IsRequired();

            //builder.Property(b => b.StateId)
            //    .HasDefaultValueSql("SELECT TOP 1 Id FROM State WHERE Code='NEW'");

            //Ignor this for ef, it is used for DTO only
            builder.Ignore(p => p.Price);
        }
    }
}
