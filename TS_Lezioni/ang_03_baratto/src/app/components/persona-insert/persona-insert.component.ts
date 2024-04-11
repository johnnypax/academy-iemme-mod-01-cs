import { Component } from '@angular/core';
import { Persona } from '../../models/persona';
import { PersonaService } from '../../services/persona.service';

@Component({
  selector: 'app-persona-insert',
  templateUrl: './persona-insert.component.html',
  styleUrl: './persona-insert.component.css'
})
export class PersonaInsertComponent {

  nominativo: string | undefined;
  showErrore: boolean = false;

  constructor(private service: PersonaService){

  }

  salva(){
    this.showErrore = false;

    if(this.nominativo?.trim() == ""){
      this.showErrore = true;
    }

    if(this.nominativo != undefined){
      let per = new Persona(this.nominativo);

      if(this.service.Insert(per)){
        console.log("STAPPOOOO")
        this.nominativo = "";
      }
      else{
        console.log("Erorre");
        
      }
    }
      

  }

}
