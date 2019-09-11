import { TestBed } from '@angular/core/testing';

import { CsoFormDataService } from './cso-form-data.service';

describe('CsoFormDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CsoFormDataService = TestBed.get(CsoFormDataService);
    expect(service).toBeTruthy();
  });
});
