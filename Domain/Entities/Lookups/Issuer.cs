using System.Collections.Generic;

namespace Domain.Entities.Lookups
{
    public class Issuer : LookupBase
    {
        public Issuer()
        {
            Requests = new HashSet<Request>();
        }
        public int PackageExpiryInHours { get; set; }
        public string PackageDescription { get; set; }
        public string Phone { get; set; }
        public int ReplyPeriod { get; set; }
        public string HomePageUrl { get; set; }
        public ICollection<Request> Requests { get; private set; }
    }
}
