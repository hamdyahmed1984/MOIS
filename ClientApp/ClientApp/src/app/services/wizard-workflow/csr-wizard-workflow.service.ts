import { Injectable } from '@angular/core';
import { WizardWorkflowService } from './wizard-workflow.service';
import { CsrWizardStepEnum } from './../../models/wizard/csr-wizard-steps';
import { WizardStep } from './../../models/wizard/wizard-step';

@Injectable({
  providedIn: 'root'
})
export class CsrWizardWorkflowService extends WizardWorkflowService {


  constructor() {
    let wizardSteps: WizardStep[] = [
      { Step: CsrWizardStepEnum.Requester, Valid: false },
      { Step: CsrWizardStepEnum.AddressGroup, Valid: false },
      { Step: CsrWizardStepEnum.CsrDocument, Valid: false },
      { Step: CsrWizardStepEnum.Confirm, Valid: false }];

    super(wizardSteps);
  }
}
