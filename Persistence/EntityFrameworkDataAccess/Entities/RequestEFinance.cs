using System;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class RequestEFinance : BaseEntity
    {
        //public int RequestStateId { get; set; }
        public RequestState RequestState { get; set; }
        public string SenderId { get; set; }
        public string SenderName { get; set; }
        public string SenderRandomValue { get; set; }
        public string SenderPassword { get; set; }
        public string SenderRequestNumber { get; set; }
        public string PaymentRequestNumber { get; set; }
        public decimal? PaymentRequestTotalAmount { get; set; }
        public decimal? CollectionFeesAmount { get; set; }
        public decimal? CustomerAuthorizationAmount { get; set; }
        public string AuthorizingMechanism { get; set; }
        public DateTime? AuthoriztionDateTime { get; set; }
        public DateTime? ReconciliationDate { get; set; }
        public bool? IsConfirmed { get; set; }
    }
}
