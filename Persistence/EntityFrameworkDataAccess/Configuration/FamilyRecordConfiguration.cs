using Domain.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class FamilyRecordConfiguration : IEntityTypeConfiguration<FamilyRecord>
    {
        public void Configure(EntityTypeBuilder<FamilyRecord> builder)
        {
            builder.Property(p => p.NID)
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(p => p.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FatherName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.GrandFatherName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.FamilyName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.MotherFullName)
                .HasMaxLength(100)
                .IsRequired();

            //builder.Property(b => b.StateId)
            //    .HasDefaultValueSql("SELECT TOP 1 Id FROM State WHERE Code='NEW'");

            //Ignor this for ef, it is used for DTO only
            builder.Ignore(p => p.Price);
        }
    }
}
