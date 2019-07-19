namespace ClientApp.Controllers.Resources
{
    public class DeathDocResourceIn : DeathDocResource
    { }
    public class DeathDocResourceOut : DeathDocResource
    {
        public int? Id { get; set; }
        public int? RequestId { get; set; }
        public decimal Price { get; set; }
        public int StateId { get; set; }
    }
    public class DeathDocResource
    {
        public int NumberOfCopies { get; set; }
        public RequesterNameResource Name { get; set; }
        public string MotherFullName { get; set; }
        public int GenderId { get; set; }
        public NIDResource NID { get; set; }
        public int RelationId { get; set; }
    }
}
