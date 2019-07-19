using System;

namespace Domain.Entities
{
    public class EligibleNID : BaseEntity
    {
        public string HashedNID { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
    }
}
