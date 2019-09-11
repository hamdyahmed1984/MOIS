import { RequesterNameModel } from '../RequestModel';

export class NidDocModel {
    Name: RequesterNameModel;
    JobName: string;
    NidIssueReasonId: number;
    JobTypeNIDId: number;
    IsFirstTime: boolean;
}
