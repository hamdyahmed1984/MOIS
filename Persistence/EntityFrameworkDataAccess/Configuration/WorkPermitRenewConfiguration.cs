using Domain.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class WorkPermitRenewConfiguration : IEntityTypeConfiguration<WorkPermitRenew>
    {
        public void Configure(EntityTypeBuilder<WorkPermitRenew> builder)
        {
            builder.Property(p => p.JobNameInEgypt)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.NidFileName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.PassportFileName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.VisaFileName)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.PreviousPermitFileName)
               .HasMaxLength(100);

            builder.Property(p => p.VacationPermitFileName)
              .HasMaxLength(100);

            builder.Property(p => p.NavyAgentCertFileName)
              .HasMaxLength(100);

            builder.Property(p => p.NavyPassportFileName)
              .HasMaxLength(100);

            //builder.Property(b => b.StateId)
            //    .HasDefaultValueSql("SELECT TOP 1 Id FROM State WHERE Code='NEW'");

            //Ignor this for ef, it is used for DTO only
            builder.Ignore(p => p.Price);
        }
    }
}
