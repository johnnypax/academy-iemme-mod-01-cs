import { Component } from '@angular/core';
import { Persona } from '../persona';

@Component({
  selector: 'app-prova',
  templateUrl: './prova.component.html',
  styleUrl: './prova.component.css'
})
export class ProvaComponent {

  constructor(){

    let gio = new Persona();
    gio.nome = "GIovanni";
    gio.cognome = "Pace";
    gio.eta = 37;

  }

  ngOnInit(): void {
    console.log("Sono il ngOnInit di ProvaComponent")
  }

}
