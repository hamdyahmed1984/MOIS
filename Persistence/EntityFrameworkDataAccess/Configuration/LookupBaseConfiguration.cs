using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityFrameworkDataAccess.Configuration
{
    public class LookupBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : LookupBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.Code)
                .HasMaxLength(20).
                IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }

    public class GenderConfiguration : LookupBaseConfiguration<Gender>
    {
        public override void Configure(EntityTypeBuilder<Gender> builder)
        {            
            base.Configure(builder);
            builder.ToTable("Gender");
        }
    }

    public class CountryConfiguration : LookupBaseConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {            
            base.Configure(builder);
            builder.ToTable("Country");
        }
    }
    public class ClearanceReasonConfiguration : LookupBaseConfiguration<ClearanceReason>
    {
        public override void Configure(EntityTypeBuilder<ClearanceReason> builder)
        {            
            base.Configure(builder);
            builder.ToTable("ClearanceReason");
        }
    }
    public class CurrencyConfiguration : LookupBaseConfiguration<Currency>
    {
        public override void Configure(EntityTypeBuilder<Currency> builder) => base.Configure(builder);
    }
    public class DocumentTypeConfiguration : LookupBaseConfiguration<DocumentType>
    {
        public override void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            base.Configure(builder);
            builder.ToTable("DocumentType");

            builder.Property(p => p.Price)
                .HasColumnType("DECIMAL(15, 5)");

            builder.Property(p => p.Agreement)
                .IsRequired();
        }
    }
    public class ForeignContractorTypeConfiguration : LookupBaseConfiguration<ForeignContractorType>
    {
        public override void Configure(EntityTypeBuilder<ForeignContractorType> builder)
        {
            base.Configure(builder);
            builder.ToTable("ForeignContractorType");
        }
    }
    public class ForeignContractTypeConfiguration : LookupBaseConfiguration<ForeignContractType>
    {
        public override void Configure(EntityTypeBuilder<ForeignContractType> builder)
        {
            base.Configure(builder);
            builder.ToTable("ForeignContractType");
        }
    }
    public class GovernmentalEstablishmentConfiguration : LookupBaseConfiguration<GovernmentalEstablishment>
    {
        public override void Configure(EntityTypeBuilder<GovernmentalEstablishment> builder)
        {
            base.Configure(builder);
            builder.ToTable("GovernmentalEstablishment");
        }
    }
    public class GovernmentalEstablishmentTypeConfiguration : LookupBaseConfiguration<GovernmentalEstablishmentType>
    {
        public override void Configure(EntityTypeBuilder<GovernmentalEstablishmentType> builder)
        {
            base.Configure(builder);
            builder.ToTable("GovernmentalEstablishmentType");
        }
    }
    public class GovernorateConfiguration : LookupBaseConfiguration<Governorate>
    {
        public override void Configure(EntityTypeBuilder<Governorate> builder)
        {
            base.Configure(builder);
            builder.ToTable("Governorate");
        }
    }
    public class IssuerConfiguration : LookupBaseConfiguration<Issuer>
    {
        public override void Configure(EntityTypeBuilder<Issuer> builder)
        {
            base.Configure(builder);
            builder.ToTable("Issuer");
            builder.Property(p => p.PackageDescription)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.HomePageUrl)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
    public class JobConfiguration : LookupBaseConfiguration<Job>
    {
        public override void Configure(EntityTypeBuilder<Job> builder)
        {
            base.Configure(builder);
            builder.ToTable("Job");
        }
    }
    public class JobTypeNIDConfiguration : LookupBaseConfiguration<JobTypeNID>
    {
        public override void Configure(EntityTypeBuilder<JobTypeNID> builder)
        {
            base.Configure(builder);
            builder.ToTable("JobTypeNID");
        }
    }
    public class JobTypeWorkPermitConfiguration : LookupBaseConfiguration<JobTypeWorkPermit>
    {
        public override void Configure(EntityTypeBuilder<JobTypeWorkPermit> builder)
        {
            base.Configure(builder);
            builder.ToTable("JobTypeWorkPermit");
        }
    }
    public class MinistryConfiguration : LookupBaseConfiguration<Ministry>
    {
        public override void Configure(EntityTypeBuilder<Ministry> builder)
        {
            base.Configure(builder);
            builder.ToTable("Ministry");
        }
    }
    public class NidIssueReasonConfiguration : LookupBaseConfiguration<NidIssueReason>
    {
        public override void Configure(EntityTypeBuilder<NidIssueReason> builder)
        {
            base.Configure(builder);
            builder.ToTable("NidIssueReason");
        }
    }
    public class OrderStatusConfiguration : LookupBaseConfiguration<OrderStatus>
    {
        public override void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            base.Configure(builder);
            builder.ToTable("OrderStatus");
        }
    }
    public class PassportIssuerConfiguration : LookupBaseConfiguration<PassportIssuer>
    {
        public override void Configure(EntityTypeBuilder<PassportIssuer> builder)
        {
            base.Configure(builder);
            builder.ToTable("PassportIssuer");
        }
    }
    public class PaymentMethodConfiguration : LookupBaseConfiguration<PaymentMethod>
    {
        public override void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            base.Configure(builder);
            builder.ToTable("PaymentMethod");
        }
    }
    public class PoliceDepartmentConfiguration : LookupBaseConfiguration<PoliceDepartment>
    {
        public override void Configure(EntityTypeBuilder<PoliceDepartment> builder)
        {
            base.Configure(builder);
            builder.ToTable("PoliceDepartment");
        }
    }
    public class PostalCodeConfiguration : LookupBaseConfiguration<PostalCode>
    {
        public override void Configure(EntityTypeBuilder<PostalCode> builder)
        {
            base.Configure(builder);
            builder.ToTable("PostalCode");

            builder.Property(p => p.Address)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
    public class QualificationConfiguration : LookupBaseConfiguration<Qualification>
    {
        public override void Configure(EntityTypeBuilder<Qualification> builder)
        {
            base.Configure(builder);
            builder.ToTable("Qualification");
        }
    }
    public class QualificationTypeConfiguration : LookupBaseConfiguration<QualificationType>
    {
        public override void Configure(EntityTypeBuilder<QualificationType> builder)
        {
            base.Configure(builder);
            builder.ToTable("QualificationType");
        }
    }
    public class RegionConfiguration : LookupBaseConfiguration<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            base.Configure(builder);
            builder.ToTable("Region");
        }
    }
    public class RejectionReasonConfiguration : LookupBaseConfiguration<RejectionReason>
    {
        public override void Configure(EntityTypeBuilder<RejectionReason> builder)
        {
            base.Configure(builder);
            builder.ToTable("RejectionReason");
        }
    }
    public class ReturnReasonConfiguration : LookupBaseConfiguration<ReturnReason>
    {
        public override void Configure(EntityTypeBuilder<ReturnReason> builder)
        {
            base.Configure(builder);
            builder.ToTable("ReturnReason");
        }
    }
    public class StateConfiguration : LookupBaseConfiguration<State>
    {
        public override void Configure(EntityTypeBuilder<State> builder)
        {
            base.Configure(builder);
            builder.ToTable("State");

            builder.Property(p => p.Code)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(2048)
                .IsRequired();
        }
    }
    public class UnitConfiguration : LookupBaseConfiguration<Unit>
    {
        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            base.Configure(builder);
            builder.ToTable("Unit");

            builder.Property(p => p.Address)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
    public class VacationTypeConfiguration : LookupBaseConfiguration<VacationType>
    {
        public override void Configure(EntityTypeBuilder<VacationType> builder)
        {
            base.Configure(builder);
            builder.ToTable("VacationType");
        }
    }
    public class WorkPermitIssueReasonConfiguration : LookupBaseConfiguration<WorkPermitIssueReason>
    {
        public override void Configure(EntityTypeBuilder<WorkPermitIssueReason> builder)
        {
            base.Configure(builder);
            builder.ToTable("WorkPermitIssueReason");
        }
    }   
}
