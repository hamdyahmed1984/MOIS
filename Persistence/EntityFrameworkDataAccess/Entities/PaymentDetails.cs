using System;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class PaymentDetails: BaseEntity
    {
        public int RequestId { get; set; }
        public Request Request { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Notes { get; set; }

        #region Internal fields
        public string IPAddress { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        #endregion
    }
}
