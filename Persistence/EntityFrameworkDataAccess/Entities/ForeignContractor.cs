using Domain.Entities.Lookups;

namespace Persistence.EntityFrameworkDataAccess.Entities
{
    public class ForeignContractor : BaseEntity
    {
        public int ContractorCountryId { get; set; }
        public Country ContractorCountry { get; set; }
        public string ContractorName { get; set; }
        public int ContractorTypeId { get; set; }
        public ForeignContractorType ContractorType { get; set; }
        public string ContractorActivity { get; set; }
        public string ContractorJobName { get; set; }
        public int ContractTypeId { get; set; }
        public ForeignContractType ContractType { get; set; }
        public int YearsToRenew { get; set; }
        public bool WorkPlaceIsOnShips { get; set; }
        public string VisaNoOrAccomodationNo { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public decimal Salary { get; set; }

        #region Address details
        public int AddressCountryId { get; set; }
        public Country AddressCountry { get; set; }
        public string AddressCity { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressStreet { get; set; }
        public string AddressBuilding { get; set; }
        #endregion
    }
}
