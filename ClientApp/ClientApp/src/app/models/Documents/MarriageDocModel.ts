import { RequesterNameModel, NID } from '../RequestModel';

export class MarriageDocModel {
    NumberOfCopies: number;
    Name: RequesterNameModel;
    NID: NID;
    SpouseFullName: string;
    RelationId: number;
}
