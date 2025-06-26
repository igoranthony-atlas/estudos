import { TestBed } from '@angular/core/testing';

import { ProductDataTranferService } from './productDataTranfer.service';

describe('UserService', () => {
  let service: ProductDataTranferService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductDataTranferService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
