using Domain.Entities.Lookups;
using System;

namespace Domain.Entities.Documents
{
    public class WorkPermitClearance: DocumentBase
    {
        public int PassportId { get; set; }
        public Passport Passport { get; set; }
        public DateTime LastPermitFinishDate { get; set; }
        public string ClearanceDestination { get; set; }
        public int ClearanceReasonId { get; set; }
        public ClearanceReason ClearanceReason { get; set; }

        #region Uploaded Files
        public string NidFileName { get; set; }
        public string PassportFileName { get; set; }
        public string PreviousPermitFileName { get; set; }
        public string VisaFileName { get; set; }
        public string RenewDirectedLetterFileName { get; set; }
        public string NavyAgentCertFileName { get; set; }
        #endregion
    }
}
