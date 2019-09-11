import { RequesterNameModel, NID } from '../RequestModel';

export class DivorceDocModel {
    NumberOfCopies: number;
    Name: RequesterNameModel;
    NID: NID;
    SpouseFullName: string;
    RelationId: number;
}
