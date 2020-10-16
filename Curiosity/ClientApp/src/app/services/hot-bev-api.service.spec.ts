import { TestBed } from '@angular/core/testing';

import { HotBevApiService } from './hot-bev-api.service';

describe('HotBevApiService', () => {
  let service: HotBevApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotBevApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
