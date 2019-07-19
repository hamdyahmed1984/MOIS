import { Injectable } from '@angular/core';
import { WizardStep } from './../../models/wizard/wizard-step';

@Injectable({
  providedIn: 'root'
})
export class WizardWorkflowService {

  constructor(private steps: WizardStep[]) { }

  validateStep(step: string) {
    // If the state is found, set the valid field to true
    let found = false;
    for (let i = 0; i < this.steps.length && !found; i++) {
      if (this.steps[i].Step === step)
        found = this.steps[i].Valid = true;
    }
  }

  unValidateStep(step: string) {
    // If the state is found, set the valid field to true
    let found = false;
    for (let i = 0; i < this.steps.length; i++) {
      if (this.steps[i].Step === step) {
        this.steps[i].Valid = false;
        break;
      }
    }
  }

  resetAllSteps() {
    // Reset all the steps in the Workflow to be invalid
    this.steps.forEach(elm => {
      elm.Valid = false;
    });
  }

  getFirstInvalidStep(step: string): string {
    // If all the previous steps are validated, return blank
    // Otherwise, return the first invalid step
    let valid = true;
    let found = false;
    var redirectToStep = '';
    for (let i = 0; i < this.steps.length && valid && !found; i++) {
      let itm = this.steps[i];
      if (itm.Step === step) {
        found = true;
        redirectToStep = '';
      }
      else {
        valid = itm.Valid;
        redirectToStep = itm.Step;
      }
    }
    return redirectToStep;
  }
}
