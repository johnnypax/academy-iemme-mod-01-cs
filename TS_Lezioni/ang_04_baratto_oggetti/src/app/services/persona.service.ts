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
  Update(obj: Persona) : boolean{
    for(let i=0; i<this.elenco.length; i++){
      if(this.elenco[i].codice == obj.codice){
        this.elenco[i].nominativo = obj.nominativo;   //Unico campo che hai la possibilità di modifica
        
        localStorage.setItem("elenco_persone", JSON.stringify(this.elenco));

        return true;
      }
    }

        
    return false;
  }
}
