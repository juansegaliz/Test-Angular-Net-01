import { TestBed } from '@angular/core/testing';

import { HttpMaritimeLogisticsService } from './http-maritime-logistics.service';

describe('HttpMaritimeLogisticsService', () => {
  let service: HttpMaritimeLogisticsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpMaritimeLogisticsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
