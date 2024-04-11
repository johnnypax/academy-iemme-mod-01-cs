import { TestBed } from '@angular/core/testing';

import { OggettoService } from './oggetto.service';

describe('OggettoService', () => {
  let service: OggettoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OggettoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
