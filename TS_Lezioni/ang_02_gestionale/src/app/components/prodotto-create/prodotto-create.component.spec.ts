import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdottoCreateComponent } from './prodotto-create.component';

describe('ProdottoCreateComponent', () => {
  let component: ProdottoCreateComponent;
  let fixture: ComponentFixture<ProdottoCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProdottoCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProdottoCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
