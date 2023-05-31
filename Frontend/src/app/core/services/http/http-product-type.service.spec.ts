import { TestBed } from '@angular/core/testing';

import { HttpProductTypesService } from './http-product-type.service';

describe('HttpProductTypesService', () => {
  let service: HttpProductTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpProductTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
