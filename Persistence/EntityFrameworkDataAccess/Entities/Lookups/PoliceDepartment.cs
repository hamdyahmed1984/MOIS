namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class PoliceDepartment : LookupBase
    {
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
    }
}
