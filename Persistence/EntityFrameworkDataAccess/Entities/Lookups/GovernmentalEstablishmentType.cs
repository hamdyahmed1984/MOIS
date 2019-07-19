using System.Collections.Generic;

namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class GovernmentalEstablishmentType : LookupBase
    {
        public GovernmentalEstablishmentType()
        {
            GovernmentalEstablishments = new HashSet<GovernmentalEstablishment>();
        }
        public ICollection<GovernmentalEstablishment> GovernmentalEstablishments { get; private set; }
    }
}