import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonaListComponent } from './persona-list.component';

describe('PersonaListComponent', () => {
  let component: PersonaListComponent;
  let fixture: ComponentFixture<PersonaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PersonaListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PersonaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
