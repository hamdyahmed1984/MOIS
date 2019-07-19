using Domain.Entities.Lookups;
using System;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class DocumentBase : BaseEntity
    {
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int NumberOfCopies { get; set; }
        public int RequestId { get; set; }        
        public Request Request { get; set; }

        #region Internal fields
        public string IPAddress { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime? LastEditDate { get; set; }
        #endregion
    }
}
