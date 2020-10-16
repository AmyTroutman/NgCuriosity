import { TestBed } from '@angular/core/testing';

import { HotBevService } from './hot-bev.service';

describe('HotBevService', () => {
  let service: HotBevService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotBevService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
