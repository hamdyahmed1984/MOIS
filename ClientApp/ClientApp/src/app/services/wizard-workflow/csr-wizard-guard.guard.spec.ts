import { TestBed, async, inject } from '@angular/core/testing';

import { CsrWizardGuardGuard } from './csr-wizard-guard.guard';

describe('CsrWizardGuardGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CsrWizardGuardGuard]
    });
  });

  it('should ...', inject([CsrWizardGuardGuard], (guard: CsrWizardGuardGuard) => {
    expect(guard).toBeTruthy();
  }));
});
