using Domain.Entities.Lookups;
using System;

namespace Domain.Entities
{
    public class RequestState : BaseEntity
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int? RejectionReasonId { get; set; }
        public RejectionReason RejectionReason { get; set; }
        public int? ReturnReasonId { get; set; }
        public ReturnReason ReturnReason { get; set; }
        public int? RequestFawryId { get; set; }
        public RequestFawry RequestFawry { get; set; }
        public int? RequestEFinanceId { get; set; }
        public RequestEFinance RequestEFinance { get; set; }
        public int? RequestPostalId { get; set; }
        public RequestPostal RequestPostal { get; set; }


        #region Internal fields
        public string IPAddress { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime? LastEditDate { get; set; }
        #endregion
    }
}
