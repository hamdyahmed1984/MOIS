using System.Collections.Generic;

namespace Domain.Entities.Lookups
{
    public class Governorate : LookupBase
    {
        public Governorate()
        {
            Units = new HashSet<Unit>();
            PoliceDepartments = new HashSet<PoliceDepartment>();
            PostalCodes = new HashSet<PostalCode>();
        }
        public int? PostDeliveryDays { get; set; }
        public ICollection<Unit> Units { get; private set; }
        public ICollection<PoliceDepartment> PoliceDepartments { get; private set; }
        public ICollection<PostalCode> PostalCodes { get; private set; }
    }
}
