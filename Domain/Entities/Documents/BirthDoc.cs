using Domain.Entities.Lookups;
using Domain.ValueObjects;

namespace Domain.Entities.Documents
{
    public class BirthDoc : DocumentBase
    {
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public NID NID { get; set; }
        public RequesterName Name { get; set; }
        public string MotherFullName { get; set; }
        public int RelationId { get; set; }
        public Relation Relation { get; set; }
        public bool IsFirstTime { get; set; }
    }
}
