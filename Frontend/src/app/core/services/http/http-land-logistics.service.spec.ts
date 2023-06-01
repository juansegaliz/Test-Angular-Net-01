import { TestBed } from '@angular/core/testing';

import { HttpLandLogisticsService } from './http-land-logistics.service';

describe('HttpLandLogisticsService', () => {
  let service: HttpLandLogisticsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpLandLogisticsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
