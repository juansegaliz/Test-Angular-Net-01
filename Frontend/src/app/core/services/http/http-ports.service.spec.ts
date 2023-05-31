import { TestBed } from '@angular/core/testing';

import { HttpPortsService } from './http-ports.service';

describe('HttpPortsService', () => {
  let service: HttpPortsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpPortsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
