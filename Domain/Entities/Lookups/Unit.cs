namespace Domain.Entities.Lookups
{
    public class Unit : LookupBase
    {
        public string Address { get; set; }
        public int GovernorateId { get; set; }
        public Governorate Governorate { get; set; }
    }
}
