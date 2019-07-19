namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class PostalCode : LookupBase
    {
        public string Address { get; set; }
        public int? PoliceDepartmentId { get; set; }
        public PoliceDepartment PoliceDepartment { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
    }
}
