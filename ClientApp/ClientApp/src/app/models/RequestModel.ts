
export class RequestModel {
  Id: number;
  Name: RequesterNameModel;
  MotherFullName: string;
  GenderId: number
  NID: NID;
  ContactDetails: ContactDetailsModel;
  ResidencyAddress: AddressModel;
  DeliveryAddress: AddressModel;
  PaymentMethodId: number;
  IssuerId: number;
}

export class RequesterNameModel {
  FirstName: string;
  FatherName: string;
  GrandFatherName: string;
  FamilyName: string;
  FullName: string;
}

export class NID {
  NationalIdenNumber: string;
  constructor(nid: string) {
    this.NationalIdenNumber = nid;
  }
}

export class ContactDetailsModel {
  Mobile1: string;
  Mobile2: string;
  PhoneHome: string;
  PhoneWork: string;
  Email: string;
}

export class AddressModel {
  FlatNumber: number;
  FloorNumber: number;
  BuildingNumber: string;
  StreetName: string;
  DistrictName: string;
  GovernorateId: number;
  PoliceDepartmentId: number;
  PostalCodeId: number;
}

export class AddressGroupModel {
  ResidencyAddress: AddressModel;
  DeliveryAddress: AddressModel;
  ResidencyAddressSameAsDeliveryAddress: boolean;
}
