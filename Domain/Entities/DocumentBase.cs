using Domain.Entities.Lookups;
using System;

namespace Domain.Entities
{
    public class DocumentBase : BaseEntity
    {
        //public int DocumentTypeId { get; set; }
        //public DocumentType DocumentType { get; set; }
        public int NumberOfCopies { get; set; }
        public int RequestId { get; set; }        
        public Request Request { get; set; }
        public int? StateId { get; set; }
        public State State { get; set; }
        //Ignor this for ef, it is used for DTO only
        public decimal Price { get; set; }

        #region Internal fields
        public string IPAddress { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime? LastEditDate { get; set; }
        #endregion
    }
}
