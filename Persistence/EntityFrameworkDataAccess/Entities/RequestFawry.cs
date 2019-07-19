using Domain.Entities.Lookups;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class RequestFawry : BaseEntity
    {
        //public int RequestStateId { get; set; }
        public RequestState RequestState { get; set; }
        public string FawryRefNo { get; set; }
        public string FawryPaymentMethod { get; set; }
        public int? OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public decimal? OrderAmount { get; set; }
        public string MessageSignature { get; set; }
        public string Notes { get; set; }
    }
}
