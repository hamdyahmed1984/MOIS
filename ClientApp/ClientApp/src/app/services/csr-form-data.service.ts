import { Injectable } from '@angular/core';

import { RequestModel, AddressGroupModel } from './../models/RequestModel'
import { CriminalStateRecordModel } from './../models/Documents/CriminalStateRecordModel'
import { CsrWizardStepEnum } from './../models/wizard/csr-wizard-steps';
import { CsrWizardWorkflowService } from './wizard-workflow/csr-wizard-workflow.service';

@Injectable({
  providedIn: 'root'
})
export class CsrFormDataService {

  private isRequestModelValid: boolean = false;
  private isAddressGroupModelValid: boolean = false;
  private isCsrDocumentValid: boolean = false;

  private requestModel: RequestModel;
  private addressGroupModel: AddressGroupModel;
  private csrDocModel: CriminalStateRecordModel;

  constructor(private csrWizardWorkflowService: CsrWizardWorkflowService) {
    this.requestModel = new RequestModel();
    this.addressGroupModel = new AddressGroupModel();
    this.csrDocModel = new CriminalStateRecordModel();
  }

  getRequestModel(): RequestModel {
    return this.requestModel;
  }

  setRequestModel(requestModel: RequestModel) {
    this.requestModel = requestModel;
    this.isRequestModelValid = true;
    //Make the step valid
    this.csrWizardWorkflowService.validateStep(CsrWizardStepEnum.Requester);
  }

  resetRequestModel() {
    this.requestModel = new RequestModel();
    this.isRequestModelValid = false;
    //Make the step invalid
    this.csrWizardWorkflowService.unValidateStep(CsrWizardStepEnum.Requester);
  }

  getAddressGroupModelModel(): AddressGroupModel {
    return this.addressGroupModel;
  }

  setAddressGroupModel(addressGroupModel: AddressGroupModel) {
    this.addressGroupModel = addressGroupModel;
    this.isAddressGroupModelValid = true;
    //Make the step valid
    this.csrWizardWorkflowService.validateStep(CsrWizardStepEnum.AddressGroup);
  }

  resetAddressGroupModel() {
    this.addressGroupModel = new AddressGroupModel();
    this.isAddressGroupModelValid = false;
    //Make the step invalid
    this.csrWizardWorkflowService.unValidateStep(CsrWizardStepEnum.AddressGroup);
  }

  getCsrDocModel(): CriminalStateRecordModel {
    return this.csrDocModel;
  }

  setCsrDocModel(csrDocModel: CriminalStateRecordModel) {
    this.csrDocModel = csrDocModel;
    this.isCsrDocumentValid = true;
    //Make the step valid
    this.csrWizardWorkflowService.validateStep(CsrWizardStepEnum.CsrDocument);
  }

  resetCsrDocModel() {
    this.csrDocModel = new CriminalStateRecordModel();
    this.isCsrDocumentValid = false;
    //Make the step invalid
    this.csrWizardWorkflowService.unValidateStep(CsrWizardStepEnum.CsrDocument);
  }

  resetAll() {
    this.resetRequestModel();
    this.resetAddressGroupModel();
    this.resetCsrDocModel();
    //Make all steps invalid
    this.csrWizardWorkflowService.resetAllSteps();
  }

  isAllValid(): boolean {
    return this.isRequestModelValid && this.isAddressGroupModelValid && this.isCsrDocumentValid;
  }
}
