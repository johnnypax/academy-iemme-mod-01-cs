
import Persona from './Persona';
import { saluta, somma } from './funzioni_utilita'

// console.log( saluta("GIovanni") );
// console.log( somma(4, 6) );

let gio = new Persona("Giovani Pace");
console.log(gio.stampaDettaglio());

let val = new Persona("Valeria Verdi", "Via le mani dal naso", "Boh")
console.log(val.stampaDettaglio());