import { Injectable } from '@angular/core';
import { RequestModel, AddressGroupModel, ContactDetailsModel, RequesterNameModel, NID, AddressModel } from './../models/RequestModel';
import { DocTypesModel } from './../models/Documents/DocTypesModel';
import { CsoWizardStepEnum } from './../models/wizard/cso-wizard-steps';
import { CsoWizardWorkflowService } from './wizard-workflow/cso-wizard-workflow.service';
import { DocTypeEnum } from '../models/Documents/DocTypeEnum';
import { BirthDocModel } from '../models/Documents/BirthDocModel';
import { DeathDocModel } from '../models/Documents/DeathDocModel';
import { MarriageDocModel } from '../models/Documents/MarriageDocModel';
import { DivorceDocModel } from '../models/Documents/DivorceDocModel';
import { NidDocModel } from '../models/Documents/NidDocModel';

@Injectable({
  providedIn: 'root'
})
export class CsoFormDataService {

  private isRequestModelValid = false;
  private isAddressGroupModelValid = false;
  private isDocTypesModelValid = false;
  private isDocDetailsModelValid = false;

  private requestModel: RequestModel;
  private addressGroupModel: AddressGroupModel;
  private docTypesModel: DocTypesModel; // This model is used for DocTypes and DocDetails steps

  constructor(private csoWizardWorkflowService: CsoWizardWorkflowService) {
    this.requestModel = new RequestModel();
    this.addressGroupModel = new AddressGroupModel();
    this.docTypesModel = new DocTypesModel();
    this.setTestData();
  }

  setTestData(): any {
    return;
    this.isRequestModelValid = this.isAddressGroupModelValid = this.isDocTypesModelValid = this.isDocDetailsModelValid = true;
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.Requester);
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.AddressGroup);
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.CsoDocs);
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.CsoDocsDetails);

    this.requestModel.GenderId = 1;
    this.requestModel.MotherFullName = 'my mother';
    this.requestModel.ContactDetails = new ContactDetailsModel();
    this.requestModel.ContactDetails.Email = 'a@a.a';
    this.requestModel.ContactDetails.Mobile1 = '01001234567';
    this.requestModel.Name = new RequesterNameModel();
    this.requestModel.Name.FirstName = 'a';
    this.requestModel.Name.FatherName = 'aa';
    this.requestModel.Name.GrandFatherName = 'aaa';
    this.requestModel.Name.FamilyName = 'aaaa';
    this.requestModel.NID = new NID('28410071402991');

    this.addressGroupModel.ResidencyAddressSameAsDeliveryAddress = true;
    this.addressGroupModel.ResidencyAddress = new AddressModel();
    this.addressGroupModel.ResidencyAddress.FlatNumber = 1;
    this.addressGroupModel.ResidencyAddress.FloorNumber = 1;
    this.addressGroupModel.ResidencyAddress.BuildingNumber = '1';
    this.addressGroupModel.ResidencyAddress.StreetName = '1';
    this.addressGroupModel.ResidencyAddress.DistrictName = '1';
    this.addressGroupModel.ResidencyAddress.GovernorateId = 1;
    this.addressGroupModel.ResidencyAddress.PoliceDepartmentId = 1;
    this.addressGroupModel.ResidencyAddress.PostalCodeId = 1;

    const nameModel = new RequesterNameModel();
    nameModel.FirstName = 'a';
    nameModel.FatherName = 'aa';
    nameModel.GrandFatherName = 'aaa';
    nameModel.FamilyName = 'aaaa';

    const nid = new NID('444444');

    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.BirthDoc, 1);
    const birthDoc = (<BirthDocModel>this.docTypesModel.getNextDoc().doc);
    birthDoc.GenderId = 1;
    birthDoc.MotherFullName = 'my  orther name';
    birthDoc.NID = new NID('444444');
    birthDoc.NumberOfCopies = 3;
    birthDoc.RelationId = 1;
    birthDoc.Name = nameModel;

    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.DeathDoc, 1);
    const deathDoc = (<DeathDocModel>this.docTypesModel.getNextDoc().doc);
    deathDoc.GenderId = 1;
    deathDoc.MotherFullName = 'my  orther name';
    deathDoc.NID = nid;
    deathDoc.NumberOfCopies = 3;
    deathDoc.RelationId = 1;
    deathDoc.Name = nameModel;

    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.MarriageDoc, 1);
    const marriageDoc = (<MarriageDocModel>this.docTypesModel.getNextDoc().doc);
    marriageDoc.NID = nid;
    marriageDoc.Name = nameModel;
    marriageDoc.NumberOfCopies = 2;
    marriageDoc.RelationId = 1;
    marriageDoc.SpouseFullName = 'my wife';

    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.DivorceDoc, 1);
    const divorceDoc = (<DivorceDocModel>this.docTypesModel.getNextDoc().doc);
    divorceDoc.NID = nid;
    divorceDoc.Name = nameModel;
    divorceDoc.NumberOfCopies = 2;
    divorceDoc.RelationId = 1;
    divorceDoc.SpouseFullName = 'my wife';

    this.docTypesModel.adjustDocsCountOfType(DocTypeEnum.NidDoc, 1);
    const nidDoc = (<NidDocModel>this.docTypesModel.getNextDoc().doc);
    nidDoc.JobName = 'engineer';
    nidDoc.JobTypeNIDId = 1;
    nidDoc.Name = nameModel;
    nidDoc.NidIssueReasonId = 1;
  }

  getRequestModel(): RequestModel {
    return this.requestModel;
  }

  setRequestModel(requestModel: RequestModel) {
    this.requestModel = requestModel;
    this.isRequestModelValid = true;
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.Requester);
  }

  resetRequestModel() {
    this.requestModel = new RequestModel();
    this.isRequestModelValid = false;
    this.csoWizardWorkflowService.unValidateStep(CsoWizardStepEnum.Requester);
  }

  getAddressGroupModelModel(): AddressGroupModel {
    return this.addressGroupModel;
  }

  setAddressGroupModel(addressGroupModel: AddressGroupModel) {
    this.addressGroupModel = addressGroupModel;
    this.isAddressGroupModelValid = true;
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.AddressGroup);
  }

  resetAddressGroupModel() {
    this.addressGroupModel = new AddressGroupModel();
    this.isAddressGroupModelValid = false;
    this.csoWizardWorkflowService.unValidateStep(CsoWizardStepEnum.AddressGroup);
  }

  getDocTypesModel(): DocTypesModel {
    return this.docTypesModel;
  }

  setDocTypesModel(docTypesModel: DocTypesModel) {
    this.docTypesModel = docTypesModel;
    this.isDocTypesModelValid = true;
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.CsoDocs);
  }

  resetDocTypesModel() {
    this.docTypesModel = new DocTypesModel();
    this.isDocTypesModelValid = false;
    this.csoWizardWorkflowService.unValidateStep(CsoWizardStepEnum.CsoDocs);
  }

  getDocDetailsModel(): DocTypesModel {
    return this.docTypesModel;
  }

  setDocDetailsModel(docTypesModel: DocTypesModel) {
    this.docTypesModel = docTypesModel;
    this.isDocDetailsModelValid = true;
    this.csoWizardWorkflowService.validateStep(CsoWizardStepEnum.CsoDocsDetails);
  }

  resetDocDetailsModel() {
    this.docTypesModel = new DocTypesModel();
    this.isDocDetailsModelValid = false;
    this.csoWizardWorkflowService.unValidateStep(CsoWizardStepEnum.CsoDocsDetails);
  }

  resetAll() {
    this.resetRequestModel();
    this.resetAddressGroupModel();
    this.resetDocTypesModel();
    this.resetDocDetailsModel();
    this.csoWizardWorkflowService.resetAllSteps();
  }

  isAllValid(): boolean {
    return this.isRequestModelValid && this.isAddressGroupModelValid && this.isDocTypesModelValid;
  }
}
