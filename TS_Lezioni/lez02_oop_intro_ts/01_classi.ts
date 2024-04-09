class Automobile{
    marca: String;
    modello: String;
    constructor(varMarca: String, varModello: String){
        this.marca = varMarca;
        this.modello = varModello;
    }
    stampaDettaglio() : void{
        console.log(`Automobile: ${this.marca} ${this.modello}`)
    }
}

let automobUno = new Automobile("Lexus", "Da corsa");
// automobUno.ruote = 5;
automobUno.stampaDettaglio();