using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class Request : BaseEntity
    {
        public Request()
        {
            RequestStates = new HashSet<RequestState>();
            PaymentDetails = new HashSet<PaymentDetails>();
            BirthCertificates = new HashSet<BirthDoc>();
            CriminalStateRecords = new HashSet<CriminalStateRecord>();
            DeathRecords = new HashSet<DeathDoc>();
            DivorceRecords = new HashSet<DivorceDoc>();
            FamilyRecords = new HashSet<FamilyRecord>();
            MarriageRecords = new HashSet<MarriageDoc>();
            NationalIdenNumbers = new HashSet<NidDoc>();
            PersonalRecords = new HashSet<PersonalRecord>();
            WorkPermitRenews = new HashSet<WorkPermitRenew>();
            WorkPermitReplaces = new HashSet<WorkPermitReplace>();
            WorkPermitClearances = new HashSet<WorkPermitClearance>();
        }

        public string Code { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string MotherFullName { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string NID { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string Email { get; set; }
        public int ResidencyAddressId { get; set; }
        public Address ResidencyAddress { get; set; }
        public int DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int IssuerId { get; set; }
        public Issuer Issuer { get; set; }
        public ICollection<RequestState> RequestStates { get; private set; }
        public ICollection<PaymentDetails> PaymentDetails { get; private set; }
        public string EFinance_EncryptionKey { get; set; }

        #region Documents
        public ICollection<BirthDoc> BirthCertificates { get; private set; }
        public ICollection<CriminalStateRecord> CriminalStateRecords { get; private set; }
        public ICollection<DeathDoc> DeathRecords { get; private set; }
        public ICollection<DivorceDoc> DivorceRecords { get; private set; }
        public ICollection<FamilyRecord> FamilyRecords { get; private set; }
        public ICollection<MarriageDoc> MarriageRecords { get; private set; }
        public ICollection<NidDoc> NationalIdenNumbers { get; private set; }
        public ICollection<PersonalRecord> PersonalRecords { get; private set; }
        public ICollection<WorkPermitRenew> WorkPermitRenews { get; private set; }
        public ICollection<WorkPermitReplace> WorkPermitReplaces { get; private set; }
        public ICollection<WorkPermitClearance> WorkPermitClearances { get; private set; }
        #endregion

        #region Internal fields
        public string IPAddress { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime? LastEditDate { get; set; }
        #endregion
    }
}
