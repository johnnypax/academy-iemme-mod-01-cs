import { Injectable } from '@angular/core';
import { Oggetto } from '../models/oggetto';

@Injectable({
  providedIn: 'root'
})
export class OggettoService {

  elenco: Oggetto[] = new Array();

  constructor() { 
    let stringElenco = localStorage.getItem("elenco_oggetti");
    if(!stringElenco){
      localStorage.setItem("elenco_oggetti", JSON.stringify([]));
    }
    else{
      this.elenco = JSON.parse(stringElenco)
    }
  }

  GetAll() : Oggetto[] {
    return this.elenco; 
   }
   GetById(id: string) : Oggetto | null {
     return this.elenco.filter(p => p.codice == id)[0];
   }
   Insert(obj: Oggetto) : boolean{
     this.elenco.push(obj);
     localStorage.setItem("elenco_oggetti", JSON.stringify(this.elenco));
     return true;
   }
   GetByCodiceProprietario(propRif: string) : Oggetto[]{
      return this.elenco.filter(o => o.proprietarioRIF == propRif);
   }
}
