import { TestBed } from '@angular/core/testing';

import { CsrFormDataService } from './csr-form-data.service';

describe('CsrFormDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CsrFormDataService = TestBed.get(CsrFormDataService);
    expect(service).toBeTruthy();
  });
});
