import { TestBed } from '@angular/core/testing';

import { CsoWizardGuardService } from './cso-wizard-guard.service';

describe('CsoWizardGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CsoWizardGuardService = TestBed.get(CsoWizardGuardService);
    expect(service).toBeTruthy();
  });
});
