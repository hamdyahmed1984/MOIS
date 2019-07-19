using Domain.Entities.Lookups;

namespace Persistence.EntityFrameworkDataAccess.Entities.Documents
{
    public class NationalIdenNumber :DocumentBase
    {
        public int NidIssueReasonId { get; set; }
        public NidIssueReason NidIssueReason { get; set; }
        public int JobTypeNIDId { get; set; }
        public JobTypeNID JobTypeNID { get; set; }
        public string JobName { get; set; }
    }
}
