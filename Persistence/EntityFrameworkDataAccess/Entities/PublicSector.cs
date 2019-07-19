using Domain.Entities.Lookups;
using System;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class PublicSector : BaseEntity
    {
        public int? GovernmentalEstablishmentId { get; set; }
        public GovernmentalEstablishment GovernmentalEstablishment { get; set; }
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }
        public DateTime VacationStart { get; set; }
        public DateTime VacationEnd { get; set; }
        public int VacationApprovedYears { get; set; }
    }
}
