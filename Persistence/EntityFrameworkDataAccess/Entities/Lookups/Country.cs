namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class Country : LookupBase
    {
        public int? RegionId { get; set; }
        public Region Region { get; set; }
        public int SortOrder { get; set; }
    }
}
