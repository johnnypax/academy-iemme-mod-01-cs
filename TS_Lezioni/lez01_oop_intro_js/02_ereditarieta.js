// class Automobile{
//     constructor(varMarca, varModello){
//         this.marca = varMarca;
//         this.modello = varModello;
//     }
//     stampaDettaglio(){
//         console.log(`Automobile: ${this.marca} ${this.modello}`)
//     }
// }

// class AutoElettrica extends Automobile{
//     constructor(varMarca, varModello, varAutonomia){
//         super(varMarca, varModello)
//         this.autonomia = varAutonomia;
//     }
//     stampaDettaglio(){
//         console.log(`Automobile Elettrica: ${this.marca} ${this.modello} ${this.autonomia}`)
//     }
// }


// let autoUno = new Automobile("BMW", "Da corsa");
// autoUno.stampaDettaglio();

// let autoDue = new AutoElettrica("Tesla", "Auto guida autonoma", 400);
// autoDue.stampaDettaglio();