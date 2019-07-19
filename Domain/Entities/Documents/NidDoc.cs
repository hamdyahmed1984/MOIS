using Domain.Entities.Lookups;
using Domain.ValueObjects;

namespace Domain.Entities.Documents
{
    public class NidDoc :DocumentBase
    {
        public RequesterName Name { get; set; }
        public int NidIssueReasonId { get; set; }
        public NidIssueReason NidIssueReason { get; set; }
        public int JobTypeNIDId { get; set; }
        public JobTypeNID JobTypeNID { get; set; }
        public string JobName { get; set; }
        public bool IsFirstTime { get; set; }
    }
}
