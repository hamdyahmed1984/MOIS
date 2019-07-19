using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class RequestConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.Property(p => p.Code)
                .HasMaxLength(20);

            builder.OwnsOne(m => m.Name, a =>
            {
                a.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(20).IsRequired();
                a.Property(p => p.FatherName).HasColumnName("FatherName").HasMaxLength(20).IsRequired();
                a.Property(p => p.GrandFatherName).HasColumnName("GrandFatherName").HasMaxLength(20).IsRequired();
                a.Property(p => p.FamilyName).HasColumnName("FamilyName").HasMaxLength(20).IsRequired();
                a.Ignore(p => p.FullName);
            });

            //builder.OwnsOne(m => m.ResidencyAddress, a =>
            //{
            //    a.Property(p => p.FlatNumber).IsRequired();
            //    a.Property(p => p.FloorNumber).IsRequired();
            //    a.Property(p => p.BuildingNumber).HasMaxLength(20).IsRequired();
            //    a.Property(p => p.StreetName).HasMaxLength(50).IsRequired();
            //    a.Property(p => p.DistrictName).HasMaxLength(50).IsRequired();
            //    a.Property(p => p.GovernorateId).IsRequired();
            //    a.Property(p => p.PoliceDepartmentId).IsRequired();
            //    a.Property(p => p.PostalCodeId).IsRequired();
            //    a.ToTable("Address");
            //});

            //builder.OwnsOne(m => m.DeliveryAddress, a =>
            //{
            //    a.Property(p => p.FlatNumber).IsRequired();
            //    a.Property(p => p.FloorNumber).IsRequired();
            //    a.Property(p => p.BuildingNumber).HasMaxLength(20).IsRequired();
            //    a.Property(p => p.StreetName).HasMaxLength(50).IsRequired();
            //    a.Property(p => p.DistrictName).HasMaxLength(50).IsRequired();
            //    a.Property(p => p.GovernorateId).IsRequired();
            //    a.Property(p => p.PoliceDepartmentId).IsRequired();
            //    a.Property(p => p.PostalCodeId).IsRequired();
            //    a.ToTable("Address");
            //});

            builder.OwnsOne(m => m.NID, a =>
            {
                a.Property(p => p.NationalIdenNumber).HasColumnName("NID").HasMaxLength(14).IsRequired();
            });

            builder.OwnsOne(m => m.ContactDetails, a =>
            {
                a.Property(p => p.Mobile1).HasMaxLength(20).IsRequired();
                a.Property(p => p.Mobile2).HasMaxLength(20);
                a.Property(p => p.PhoneHome).HasMaxLength(20);
                a.Property(p => p.PhoneWork).HasMaxLength(20);
                a.Property(p => p.Email).HasMaxLength(50).IsRequired();
            });

            //builder.Property(p => p.FirstName)
            //    .HasMaxLength(20)
            //    .IsRequired();

            //builder.Property(p => p.FatherName)
            //    .HasMaxLength(20)
            //    .IsRequired();

            //builder.Property(p => p.GrandFatherName)
            //    .HasMaxLength(20)
            //    .IsRequired();

            //builder.Property(p => p.FamilyName)
            //    .HasMaxLength(20)
            //    .IsRequired();

            builder.Property(p => p.MotherFullName)
                .HasMaxLength(100)
                .IsRequired();

            //builder.Property(p => p.NID)
            //    .HasMaxLength(14)
            //    .IsRequired();

            //builder.Property(p => p.Mobile1)
            //    .HasMaxLength(20)
            //    .IsRequired();

            //builder.Property(p => p.Mobile2)
            //    .HasMaxLength(20);

            //builder.Property(p => p.PhoneHome)
            //    .HasMaxLength(20);

            //builder.Property(p => p.PhoneWork)
            //    .HasMaxLength(20);

            //builder.Property(p => p.Email)
            //    .HasMaxLength(50)
            //    .IsRequired();

            //builder.Property(p => p.EFinance_EncryptionKey)
            //   .HasMaxLength(100);

            builder.Ignore(p => p.Price);
            builder.Ignore(p => p.PostalFees);

            /*This is to allow changing the readonly collection with ef core, it allows ef core to use the backing field instead of the readonly collection*/
            builder.Metadata.FindNavigation(nameof(Request.RequestStates)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.PaymentDetails)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.BirthDocs)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.CriminalStateRecords)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.DeathDocs)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.DivorceDocs)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.FamilyRecords)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.MarriageDocs)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.NidDoc)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.PersonalRecords)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.WorkPermitClearances)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.WorkPermitRenews)).SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.Metadata.FindNavigation(nameof(Request.WorkPermitReplaces)).SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
