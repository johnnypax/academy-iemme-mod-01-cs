import { Injectable } from '@angular/core';
import { Persona } from '../models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  elenco: Persona[] = new Array();

  constructor() { 
    let stringElenco = localStorage.getItem("elenco_persone");
    if(!stringElenco){
      localStorage.setItem("elenco_persone", JSON.stringify([]));
    }
    else{
      this.elenco = JSON.parse(stringElenco)
    }
  }

  GetAll() : Persona[] {
   return this.elenco; 
  }
  GetById(id: string) : Persona | null {
    return this.elenco.filter(p => p.codice == id)[0];
  }
  Insert(obj: Persona) : boolean{
    this.elenco.push(obj);
    localStorage.setItem("elenco_persone", JSON.stringify(this.elenco));
    return true;
  }
}
