using Domain.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class NidDocConfiguration : IEntityTypeConfiguration<NidDoc>
    {
        public void Configure(EntityTypeBuilder<NidDoc> builder)
        {
            builder.ToTable("NidDocs");

            builder.OwnsOne(m => m.Name, a =>
            {
                a.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(20).IsRequired();
                a.Property(p => p.FatherName).HasColumnName("FatherName").HasMaxLength(20).IsRequired();
                a.Property(p => p.GrandFatherName).HasColumnName("GrandFatherName").HasMaxLength(20).IsRequired();
                a.Property(p => p.FamilyName).HasColumnName("FamilyName").HasMaxLength(20).IsRequired();
                a.Ignore(p => p.FullName);
            });

            builder.Property(p => p.JobName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.NumberOfCopies).HasDefaultValue(1);
            
            //builder.Property(b => b.StateId)
            //    .HasDefaultValueSql("SELECT TOP 1 Id FROM State WHERE Code='NEW'");

            //Ignor this for ef, it is used for DTO only
            builder.Ignore(p => p.Price);
        }
    }
}
