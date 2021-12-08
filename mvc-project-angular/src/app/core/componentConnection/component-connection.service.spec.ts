import { TestBed } from '@angular/core/testing';

import { ComponentConnectionService } from './component-connection.service';

describe('ComponentConnectionService', () => {
  let service: ComponentConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ComponentConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
