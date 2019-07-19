using System.Collections.Generic;

namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class QualificationType : LookupBase
    {
        public QualificationType()
        {
            Qualifications = new HashSet<Qualification>();
        }
        public ICollection<Qualification> Qualifications { get; private set; }
    }
}
