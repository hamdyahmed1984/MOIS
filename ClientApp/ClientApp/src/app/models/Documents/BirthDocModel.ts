import { RequesterNameModel, NID } from '../RequestModel';

export class BirthDocModel {
    NumberOfCopies: number;
    Name: RequesterNameModel;
    MotherFullName: string;
    GenderId: number;
    NID: NID;
    RelationId: number;
    IsFirstTime: boolean;
}
