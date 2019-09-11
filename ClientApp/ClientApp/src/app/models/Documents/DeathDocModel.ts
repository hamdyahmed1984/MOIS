import { RequesterNameModel, NID } from '../RequestModel';

export class DeathDocModel {
    NumberOfCopies: number;
    Name: RequesterNameModel;
    MotherFullName: string;
    GenderId: number;
    NID: NID;
    RelationId: number;
}
