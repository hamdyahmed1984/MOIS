using Domain.Entities.Lookups;
using System;

namespace Domain.Entities
{
    public class Passport : BaseEntity
    {
        public string PassportNumber { get; set; }
        public DateTime PassportIssueDate { get; set; }
        public int PassportIssueCountryId { get; set; }
        public Country PassportIssueCountry { get; set; }
        public int JobInPassportId { get; set; }
        public Job JobInPassport { get; set; }
        public DateTime LastLeaveDate { get; set; }
        public DateTime LastReturnDate { get; set; }
        public int? PassportIssuerId { get; set; }
        public PassportIssuer PassportIssuer { get; set; }
    }
}
