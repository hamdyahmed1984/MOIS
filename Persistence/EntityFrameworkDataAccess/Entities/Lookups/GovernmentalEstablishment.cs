using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class GovernmentalEstablishment : LookupBase
    {
        public int? GovernmentalEstablishmentTypeId { get; set; }
        public GovernmentalEstablishmentType GovernmentalEstablishmentType { get; set; }
    }
}
