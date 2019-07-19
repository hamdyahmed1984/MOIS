import { TestBed } from '@angular/core/testing';

import { LookupsService } from './lookups.service';

describe('LookupsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LookupsService = TestBed.get(LookupsService);
    expect(service).toBeTruthy();
  });
});
