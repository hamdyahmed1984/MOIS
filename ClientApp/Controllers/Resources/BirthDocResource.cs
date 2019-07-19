namespace ClientApp.Controllers.Resources
{
    public class BirthDocResourceIn : BirthDocResource
    { }
    public class BirthDocResourceOut : BirthDocResource
    {
        public int? Id { get; set; }
        public int? RequestId { get; set; }
        public decimal Price { get; set; }
        public int StateId { get; set; }
    }
    public class BirthDocResource
    {
        public int NumberOfCopies { get; set; }
        public RequesterNameResource Name { get; set; }
        public string MotherFullName { get; set; }
        public int GenderId { get; set; }
        public NIDResource NID { get; set; }      
        public int RelationId { get; set; }
        public bool IsFirstTime { get; set; }
    }
}
