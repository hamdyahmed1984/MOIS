using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Lookups
{
    public class DocumentType : LookupBase
    {
        public DocumentType()
        {
            Relations = new HashSet<DocumentTypeRelation>();
            Regulations = new HashSet<Regulation>();
        }

        public int MaxCopies { get; set; }
        public decimal Price { get; set; }
        public int MaxBeneficiaries { get; set; }
        public bool CanBeBundled { get; set; }
        public bool IsInstantApproval { get; set; }
        public string Agreement { get; set; }
        public int IssuerId { get; set; }
        public Issuer Issuer { get; set; }       
        public virtual ICollection<DocumentTypeRelation> Relations { get; set; }
        public virtual ICollection<Regulation> Regulations { get; set; }
    }
}
