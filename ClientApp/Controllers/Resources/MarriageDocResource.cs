namespace ClientApp.Controllers.Resources
{
    public class MarriageDocResourceIn: MarriageDocResource { }
    public class MarriageDocResourceOut : MarriageDocResource {
        public int? Id { get; set; }
        public int? RequestId { get; set; }
        public decimal Price { get; set; }
        public int StateId { get; set; }
    }
    public class MarriageDocResource
    {
        public int NumberOfCopies { get; set; }
        public RequesterNameResource Name { get; set; }
        public NIDResource NID { get; set; }
        public string SpouseFullName { get; set; }
        public int RelationId { get; set; }

    }
}
