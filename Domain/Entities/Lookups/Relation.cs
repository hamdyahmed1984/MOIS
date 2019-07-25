using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Lookups
{
    public class Relation : LookupBase
    {
        public Relation() => DocumentTypeRelations = new HashSet<DocumentTypeRelation>();
        public ICollection<DocumentTypeRelation> DocumentTypeRelations { get; private set; }
    }
}
