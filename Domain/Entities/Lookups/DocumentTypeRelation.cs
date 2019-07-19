namespace Domain.Entities.Lookups
{
    public class DocumentTypeRelation
    {
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int RelationId { get; set; }
        public Relation Relation { get; set; }
        public int? GenderId { get; set; }            
        public Gender Gender { get; set; }
    }
}
