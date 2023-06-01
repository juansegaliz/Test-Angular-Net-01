import { TestBed } from '@angular/core/testing';

import { LandLogisticService } from './land-logistic.service';

describe('LandLogisticService', () => {
  let service: LandLogisticService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LandLogisticService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
