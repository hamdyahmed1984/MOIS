import { TestBed } from '@angular/core/testing';

import { WizardWorkflowService } from './wizard-workflow.service';

describe('WizardWorkflowService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WizardWorkflowService = TestBed.get(WizardWorkflowService);
    expect(service).toBeTruthy();
  });
});
