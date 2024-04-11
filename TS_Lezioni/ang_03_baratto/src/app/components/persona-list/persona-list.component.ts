import { Component } from '@angular/core';
import { PersonaService } from '../../services/persona.service';
import { Persona } from '../../models/persona';

@Component({
  selector: 'app-persona-list',
  templateUrl: './persona-list.component.html',
  styleUrl: './persona-list.component.css'
})
export class PersonaListComponent {

  lista: Persona[] = new Array();
 
  constructor(private service: PersonaService){

  }

  ngOnInit(): void {
    this.lista = this.service.GetAll();
  }

}
