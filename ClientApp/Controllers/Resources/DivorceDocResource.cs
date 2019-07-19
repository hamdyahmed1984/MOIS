namespace ClientApp.Controllers.Resources
{
    public class DivorceDocResourceIn : DivorceDocResource { }
    public class DivorceDocResourceOut : DivorceDocResource {
        public int? Id { get; set; }
        public int? RequestId { get; set; }
        public decimal Price { get; set; }
        public int StateId { get; set; }
    }
    public class DivorceDocResource
    {
        public int NumberOfCopies { get; set; }
        public RequesterNameResource Name { get; set; }
        public NIDResource NID { get; set; }
        public string SpouseFullName { get; set; }
        public int RelationId { get; set; }
    }
}
