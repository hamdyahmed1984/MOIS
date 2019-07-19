using Domain.Entities.Lookups;
using System;

namespace Domain.Entities.Documents
{
    public class WorkPermit : DocumentBase
    {
        public int BirthPlaceId { get; set; }
        public Country BirthPlace { get; set; }
        public int QualificationId { get; set; }
        public Qualification Qualification { get; set; }
        public DateTime QualificationDate { get; set; }
        public int JobTypeWorkPermitId { get; set; }
        public JobTypeWorkPermit JobTypeWorkPermit { get; set; }
        public string JobNameInEgypt { get; set; }
        public int WorkPermitIssueReasonId { get; set; }
        public WorkPermitIssueReason WorkPermitIssueReason { get; set; }
        public int PassportId { get; set; }
        public Passport Passport { get; set; }
        public int? ForeignContractorId { get; set; }
        public ForeignContractor ForeignContractor { get; set; }
        public int? PublicSectorId { get; set; }
        public PublicSector PublicSector { get; set; }

        #region Uploaded Files
        public string NidFileName { get; set; }
        public string PassportFileName { get; set; }
        public string PreviousPermitFileName { get; set; }
        public string VisaFileName { get; set; }
        public string VacationPermitFileName { get; set; }
        public string NavyAgentCertFileName { get; set; }
        public string NavyPassportFileName { get; set; }
        #endregion
    }
}
