using Domain.Entities.Lookups;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class Address : BaseEntity
    {
        public int FlatNumber { get; set; }
        public int FloorNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string DistrictName { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
        public int PoliceDepartmentId { get; set; }
        public PoliceDepartment PoliceDepartment { get; set; }
        public int PostalCodeId { get; set; }
        public PostalCode PostalCode { get; set; }
    }
}
