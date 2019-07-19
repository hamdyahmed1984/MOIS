using Domain.Entities.Lookups;

namespace Domain.Entities
{
    public class RequestPostal : BaseEntity
    {
        //public int RequestStateId { get; set; }
        public RequestState RequestState { get; set; }
        public string Message { get; set; }
        public string ItemCode { get; set; }
        /*  00 No Error
            01 Vendor in disabled
            02 Invalid user name or password
            03 Invalid item barcode format
            04 Item added before
            0100 Server error*/
        public string ErrorCode { get; set; }
    }
}
