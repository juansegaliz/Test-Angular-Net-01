import { TestBed } from '@angular/core/testing';

import { HttpWarehousesService } from './http-warehouses.service';

describe('HttpWarehousesService', () => {
  let service: HttpWarehousesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpWarehousesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
