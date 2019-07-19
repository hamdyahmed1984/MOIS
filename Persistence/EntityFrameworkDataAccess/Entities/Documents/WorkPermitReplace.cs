using Domain.Entities.Lookups;

namespace Persistence.EntityFrameworkDataAccess.Entities.Documents
{
    public class WorkPermitReplace : WorkPermit
    {
        public int? IssuingGovernorateId { get; set; }
        public Governorate IssuingGovernorate { get; set; }
        public int? IssuingUnitId { get; set; }
        public Unit IssuingUnit { get; set; }
    }
}
