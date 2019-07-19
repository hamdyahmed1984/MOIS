namespace Persistence.EntityFrameworkDataAccess.Entities.Lookups
{
    public class Regulation
    {
        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int? JobTypeNIDId { get; set; }        
        public JobTypeNID JobTypeNID { get; set; }
        public string Regulations { get; set; }
    }
}
