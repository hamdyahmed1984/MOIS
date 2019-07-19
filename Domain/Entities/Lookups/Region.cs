using System.Collections.Generic;

namespace Domain.Entities.Lookups
{
    public class Region : LookupBase
    {
        public Region()
        {
            Countries = new HashSet<Country>();
        }
        public ICollection<Country> Countries { get; private set; }
    }
}