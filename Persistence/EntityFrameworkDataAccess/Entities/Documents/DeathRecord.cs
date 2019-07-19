using Domain.Entities.Lookups;

namespace Persistence.EntityFrameworkDataAccess.Entities.Documents
{
    public class DeathRecord : DocumentBase
    {
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public string NID { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string MotherFullName { get; set; }
        public int RelationId { get; set; }
        public Relation Relation { get; set; }
    }
}
