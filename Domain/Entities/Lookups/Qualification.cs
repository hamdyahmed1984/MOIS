namespace Domain.Entities.Lookups
{
    public class Qualification : LookupBase
    {
        public int? QualificationTypeId { get; set; }
        public QualificationType QualificationType { get; set; }
    }
}
