import { Injectable } from '@angular/core';
import { WizardStep } from 'src/app/models/wizard/wizard-step';
import { CsoWizardStepEnum } from 'src/app/models/wizard/cso-wizard-steps';
import { WizardWorkflowService } from './wizard-workflow.service';

@Injectable({
  providedIn: 'root'
})
export class CsoWizardWorkflowService extends WizardWorkflowService {

  constructor() {
    const wizardSteps: WizardStep[] = [
      { Step: CsoWizardStepEnum.Requester, Valid: false },
      { Step: CsoWizardStepEnum.AddressGroup, Valid: false },
      { Step: CsoWizardStepEnum.CsoDocs, Valid: false },
      { Step: CsoWizardStepEnum.CsoDocsDetails, Valid: false },
      { Step: CsoWizardStepEnum.Confirm, Valid: false }];

    super(wizardSteps);
  }
}
