import { TestBed } from '@angular/core/testing';

import { CsoWizardWorkflowService } from './cso-wizard-workflow.service';

describe('CsoWizardWorkflowService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CsoWizardWorkflowService = TestBed.get(CsoWizardWorkflowService);
    expect(service).toBeTruthy();
  });
});
