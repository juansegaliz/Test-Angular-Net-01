import { TestBed } from '@angular/core/testing';

import { MaritimeLogisticService } from './maritime-logistic.service';

describe('MaritimeLogisticService', () => {
  let service: MaritimeLogisticService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MaritimeLogisticService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
