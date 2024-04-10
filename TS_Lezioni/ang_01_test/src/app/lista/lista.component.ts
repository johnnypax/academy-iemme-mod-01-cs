import { Component } from '@angular/core';
import { Persona } from '../persona';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrl: './lista.component.css'
})
export class ListaComponent {

  elenco: Persona[] = new Array();

  constructor(){
    
  }

  ngOnInit(): void {

    setTimeout(() => {
      this.elenco.push(new Persona("Giovanni", "Pace", 37));
      this.elenco.push(new Persona("Valeria", "Verdi", 35));
      this.elenco.push(new Persona("Marika", "Mariko", 32));
      
    }, 2000);

  }

}
