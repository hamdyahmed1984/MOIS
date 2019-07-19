using System.Collections.Generic;

namespace ClientApp.Controllers.Resources
{
    public class RequestResourceIn : RequestResource {
        public RequesterNameResource Name { get; set; }
        public string MotherFullName { get; set; }
        public int GenderId { get; set; }
        public NIDResource NID { get; set; }
        public ContactDetailsResource ContactDetails { get; set; }
        public AddressResourceIn ResidencyAddress { get; set; }
        public AddressResourceIn DeliveryAddress { get; set; }
        public IEnumerable<NidDocResourceIn> NidDoc { get; set; }
        public IEnumerable<BirthDocResourceIn> BirthDocs { get; set; }
        public IEnumerable<DeathDocResourceIn> DeathDocs { get; set; }
        public IEnumerable<MarriageDocResourceIn> MarriageDocs { get; set; }
        public IEnumerable<DivorceDocResourceIn> DivorceDocs { get; set; }
    }
    public class RequestResourceOut : RequestResource {
        public int? Id { get; set; }
        public decimal Price { get; set; }
        public decimal PostalFees { get; set; }
        public decimal TotalPrice => Price + PostalFees;
        public string RequesterFullName { get; set; }
        public string MotherFullName { get; set; }
        public int GenderId { get; set; }
        public NIDResource NID { get; set; }
        public ContactDetailsResource ContactDetails { get; set; }
        public AddressResourceOut ResidencyAddress { get; set; }
        public AddressResourceOut DeliveryAddress { get; set; }
        public IEnumerable<NidDocResourceOut> NidDoc { get; set; }
        public IEnumerable<BirthDocResourceOut> BirthDocs { get; set; }
        public IEnumerable<DeathDocResourceOut> DeathDocs { get; set; }
        public IEnumerable<MarriageDocResourceOut> MarriageDocs { get; set; }
        public IEnumerable<DivorceDocResourceOut> DivorceDocs { get; set; }
    }
    public class RequestResource
    {
        //public string Code { get; set; }
        //public int PaymentMethodId { get; set; }
        //public int IssuerId { get; set; }
    }

    public class NIDResource
    {
        public string NationalIdenNumber { get; set; }
    }

    public class RequesterNameResource
    {
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string FamilyName { get; set; }
        public string FullName => FirstName + " " + FatherName + " " + GrandFatherName + " " + FamilyName;
    }

    public class ContactDetailsResource
    {
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string Email { get; set; }
    }

    public class AddressResourceIn: AddressResource { }
    public class AddressResourceOut : AddressResource {
        //public int Id { get; set; }
    }
    public class AddressResource
    {
        public int FlatNumber { get; set; }
        public int FloorNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string DistrictName { get; set; }
        public int GovernorateId { get; set; }
        public int PoliceDepartmentId { get; set; }
        public int PostalCodeId { get; set; }
    }
}
