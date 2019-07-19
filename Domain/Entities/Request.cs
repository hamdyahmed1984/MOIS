using Domain.Entities.Documents;
using Domain.Entities.Lookups;
using Domain.ValueObjects;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Request : IAggregateRoot
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public RequesterName Name { get; private set; }        
        public string MotherFullName { get; private set; }
        public Gender Gender { get; private set; }
        public int GenderId { get; private set; }
        public NID NID { get; private set; }
        public ContactDetails ContactDetails { get; private set; }
        public Address ResidencyAddress { get; private set; }
        public int ResidencyAddressId { get; private set; }
        public Address DeliveryAddress { get; private set; }
        public int DeliveryAddressId { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public int? PaymentMethodId { get; private set; }
        public Issuer Issuer { get; private set; }
        public int IssuerId { get; private set; }

        public decimal Price { get; private set; }
        public decimal PostalFees { get; private set; }

        //Fields for collections
        private readonly List<RequestState> _requestStates = new List<RequestState>();
        private readonly List<PaymentDetails> _paymentDetails = new List<PaymentDetails>();
        private readonly List<WorkPermitRenew> _workPermitRenews = new List<WorkPermitRenew>();
        private readonly List<WorkPermitReplace> _workPermitReplaces = new List<WorkPermitReplace>();
        private readonly List<WorkPermitClearance> _workPermitClearances = new List<WorkPermitClearance>();
        private readonly List<CriminalStateRecord> _criminalStateRecords = new List<CriminalStateRecord>();
        private readonly List<BirthDoc> _birthDocs = new List<BirthDoc>();
        private readonly List<DeathDoc> _deathDocs = new List<DeathDoc>();
        private readonly List<DivorceDoc> _divorceDocs = new List<DivorceDoc>();
        private readonly List<FamilyRecord> _familyRecords = new List<FamilyRecord>();
        private readonly List<MarriageDoc> _marriageDocs = new List<MarriageDoc>();
        private readonly List<NidDoc> _nidDoc = new List<NidDoc>();
        private readonly List<PersonalRecord> _personalRecords = new List<PersonalRecord>();

        //Readonly collections to wrap the original collections
        public IReadOnlyCollection<WorkPermitRenew> WorkPermitRenews
        {
            get { return _workPermitRenews.AsReadOnly(); }
            set { AddWorkPermitRenews(value); }
        }
        public IReadOnlyCollection<WorkPermitReplace> WorkPermitReplaces
        {
            get { return _workPermitReplaces.AsReadOnly(); }
            set { AddWorkPermitReplaces(value); }
        }
        public IReadOnlyCollection<WorkPermitClearance> WorkPermitClearances
        {
            get { return _workPermitClearances.AsReadOnly(); }
            set { AddWorkPermitClearances(value); }
        }
        public IReadOnlyCollection<CriminalStateRecord> CriminalStateRecords
        {
            get { return _criminalStateRecords.AsReadOnly(); }
            set { AddCriminalStateRecords(value); }
        }
        public IReadOnlyCollection<BirthDoc> BirthDocs
        {
            get
            {
                return _birthDocs.AsReadOnly();
            }
            set
            {
                //We made the set to add items to the readonly collection through a method so we controlled our business object from outside changes
                AddBirthDocs(value);
            }
        }
        public IReadOnlyCollection<DeathDoc> DeathDocs
        {
            get { return _deathDocs.AsReadOnly(); }
            set { AddDeathDocs(value); }
        }
        public IReadOnlyCollection<DivorceDoc> DivorceDocs
        {
            get { return _divorceDocs.AsReadOnly(); }
            set { AddDivorceRecords(value); }
        }
        public IReadOnlyCollection<FamilyRecord> FamilyRecords
        {
            get { return _familyRecords.AsReadOnly(); }
            set { AddFamilyRecords(value); }
        }
        public IReadOnlyCollection<MarriageDoc> MarriageDocs
        {
            get { return _marriageDocs.AsReadOnly(); }
            set { AddMarriageRecords(value); }
        }
        public IReadOnlyCollection<NidDoc> NidDoc
        {
            get { return _nidDoc.AsReadOnly(); }
            set { AddNidDocs(value); }
        }
        public IReadOnlyCollection<PersonalRecord> PersonalRecords
        {
            get { return _personalRecords.AsReadOnly(); }
            set { AddPersonalRecords(value); }
        }
        public IReadOnlyCollection<RequestState> RequestStates
        {
            get { return _requestStates.AsReadOnly(); }
            set { AddRequestStates(value); }
        }
        public IReadOnlyCollection<PaymentDetails> PaymentDetails
        {
            get { return _paymentDetails.AsReadOnly(); }
            set { AddPaymentDetails(value); }
        }

        private Request()
        {
        }
        public Request(string code, RequesterName reqName, string motherFullName, Gender gender, NID nid, ContactDetails contactDetails,
            Address residencyAddress, Address deliveryAddress, PaymentMethod paymentMethod, Issuer issuer)
        {
            Code = code;
            Name = reqName;
            MotherFullName = motherFullName;
            Gender = gender;
            NID = nid;
            ContactDetails = contactDetails;
            ResidencyAddress = residencyAddress;
            DeliveryAddress = deliveryAddress;
            PaymentMethod = paymentMethod;
            Issuer = issuer;
        }

        public Request(string code, RequesterName reqName, string motherFullName, int genderId, string nid, ContactDetails contactDetails,
            Address residencyAddress, Address deliveryAddress, int paymentMethodId, int issuerId)
        {
            Code = code;
            Name = reqName;
            MotherFullName = motherFullName;
            GenderId = genderId;
            NID = new NID(nid);
            ContactDetails = contactDetails;
            ResidencyAddress = residencyAddress;
            DeliveryAddress = deliveryAddress;
            PaymentMethodId = paymentMethodId;
            IssuerId = issuerId;
        }

        public Request SetIssueId(int issuerId)
        {
            this.IssuerId = issuerId;
            return this;
        }

        public Request SetPrice(decimal price)
        {
            this.Price = price;
            return this;
        }

        public Request SetPostalFees(decimal postalFees)
        {
            this.PostalFees = postalFees;
            return this;
        }

        public Request AddRequestState(RequestState state)
        {
            this._requestStates.Add(state);
            return this;
        }
        private void AddRequestStates(IEnumerable<RequestState> states)
        {
            _requestStates.Clear();
            states?.ToList().ForEach(a => _requestStates.Add(a));
        }
        public Request AddPaymentDetail(PaymentDetails paymentDetail)
        {
            this._paymentDetails.Add(paymentDetail);
            return this;
        }
        private void AddPaymentDetails(IEnumerable<PaymentDetails> paymentDetails)
        {
            _paymentDetails.Clear();
            paymentDetails?.ToList().ForEach(a => _paymentDetails.Add(a));
        }
        public Request AddWorkPermitRenewDoc(WorkPermitRenew doc)
        {
            this._workPermitRenews.Add(doc);
            return this;
        }
        private void AddWorkPermitRenews(IEnumerable<WorkPermitRenew> docs)
        {
            _workPermitRenews.Clear();
            docs?.ToList().ForEach(a => _workPermitRenews.Add(a));
        }
        public Request AddWorkPermitReplaceDoc(WorkPermitReplace doc)
        {
            this._workPermitReplaces.Add(doc);
            return this;
        }
        private void AddWorkPermitReplaces(IEnumerable<WorkPermitReplace> docs)
        {
            _workPermitReplaces.Clear();
            docs?.ToList().ForEach(a => _workPermitReplaces.Add(a));
        }
        public Request AddDWorkPermitClearanceDoc(WorkPermitClearance doc)
        {
            this._workPermitClearances.Add(doc);
            return this;
        }
        private void AddWorkPermitClearances(IEnumerable<WorkPermitClearance> docs)
        {
            _workPermitClearances.Clear();
            docs?.ToList().ForEach(a => _workPermitClearances.Add(a));
        }
        public Request AddCriminalStateRecordDoc(CriminalStateRecord doc)
        {
            this._criminalStateRecords.Add(doc);
            return this;
        }
        private void AddCriminalStateRecords(IEnumerable<CriminalStateRecord> docs)
        {
            _criminalStateRecords.Clear();
            docs?.ToList().ForEach(a => _criminalStateRecords.Add(a));
        }
        public Request AddBirthDoc(BirthDoc doc)
        {
            this._birthDocs.Add(doc);
            return this;
        }
        private void AddBirthDocs(IEnumerable<BirthDoc> docs)
        {
            _birthDocs.Clear();
            docs?.ToList().ForEach(a => _birthDocs.Add(a));
        }
        public Request AddDeathRecordDoc(DeathDoc doc)
        {
            this._deathDocs.Add(doc);
            return this;
        }
        private void AddDeathDocs(IEnumerable<DeathDoc> docs)
        {
            _deathDocs.Clear();
            docs?.ToList().ForEach(a => _deathDocs.Add(a));
        }
        public Request AddDivorceRecordDoc(DivorceDoc doc)
        {
            this._divorceDocs.Add(doc);
            return this;
        }
        private void AddDivorceRecords(IEnumerable<DivorceDoc> docs)
        {
            _divorceDocs.Clear();
            docs?.ToList().ForEach(a => _divorceDocs.Add(a));
        }
        public Request AddFamilyRecordDoc(FamilyRecord doc)
        {
            this._familyRecords.Add(doc);
            return this;
        }
        private void AddFamilyRecords(IEnumerable<FamilyRecord> docs)
        {
            _familyRecords.Clear();
            docs?.ToList().ForEach(a => _familyRecords.Add(a));
        }
        public Request AddMarriageRecordDoc(MarriageDoc doc)
        {
            this._marriageDocs.Add(doc);
            return this;
        }
        private void AddMarriageRecords(IEnumerable<MarriageDoc> docs)
        {
            _marriageDocs.Clear();
            docs?.ToList().ForEach(a => _marriageDocs.Add(a));
        }
        public Request AddNidDoc(NidDoc doc)
        {
            this._nidDoc.Add(doc);
            return this;
        }
        private void AddNidDocs(IEnumerable<NidDoc> docs)
        {
            _nidDoc.Clear();
            docs?.ToList().ForEach(a => _nidDoc.Add(a));
        }
        public Request AddPersonalRecordDoc(PersonalRecord doc)
        {
            this._personalRecords.Add(doc);
            return this;
        }
        private void AddPersonalRecords(IEnumerable<PersonalRecord> docs)
        {
            _personalRecords.Clear();
            docs?.ToList().ForEach(a => _personalRecords.Add(a));
        }

        public Request ChangePaymentMethod(PaymentMethod paymentMethod)
        {
            PaymentMethod = paymentMethod;
            return this;
        }

        public int GetDocsCount()
        {
            return this.BirthDocs.Count +
                this.CriminalStateRecords.Count +
                this.DeathDocs.Count +
                this.DivorceDocs.Count +
                this.FamilyRecords.Count +
                this.MarriageDocs.Count +
                this.NidDoc.Count +
                this.PersonalRecords.Count +
                this.WorkPermitClearances.Count +
                this.WorkPermitRenews.Count +
                this.WorkPermitReplaces.Count;
        }
    }
}
