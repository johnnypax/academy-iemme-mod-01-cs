class Componente{
    private descrizione: String;

    constructor(varDesc: String){
        this.descrizione = varDesc
    }
}

class Auto{

    private motore: Componente[];
    private marca: String;

    constructor(){

    }

    public setMarca(varMarca: String) : void{
        this.marca = varMarca;
    }
    public getMarca() : String{
        return this.marca
    }

    public addComponente(objCom: Componente) : void{
        if(!this.motore)
            this.motore = new Array();

        this.motore.push(objCom);
    }
}

let au = new Auto();
au.setMarca("Audi");

au.addRuota( new Ruota(16) )
au.addRuota( new Ruota(16) )
au.addRuota( new Ruota(16) )
au.addRuota( new Ruota(16) )

au.stampaDet();