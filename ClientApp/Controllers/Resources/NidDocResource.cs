namespace ClientApp.Controllers.Resources
{
    public class NidDocResourceIn : NidDocResource { }
    public class NidDocResourceOut : NidDocResource {
        public int? Id { get; set; }
        public int? RequestId { get; set; }
        public int StateId { get; set; }
        public decimal Price { get; set; }
    }
    public class NidDocResource
    {
        //public int NumberOfCopies { get; set; }
        public RequesterNameResource Name { get; set; }        
        public string JobName { get; set; }
        public int NidIssueReasonId { get; set; }
        public int JobTypeNIDId { get; set; }
        public bool IsFirstTime { get; set; }
    }
}
