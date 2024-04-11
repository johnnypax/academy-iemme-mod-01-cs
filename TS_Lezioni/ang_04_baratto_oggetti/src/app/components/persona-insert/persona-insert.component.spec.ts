import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaInsertComponent } from './persona-insert.component';

describe('PersonaInsertComponent', () => {
  let component: PersonaInsertComponent;
  let fixture: ComponentFixture<PersonaInsertComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PersonaInsertComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonaInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
