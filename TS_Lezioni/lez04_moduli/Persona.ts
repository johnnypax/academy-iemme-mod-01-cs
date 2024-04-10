class Indirizzo{
    private via: String;
    private citta: String

    constructor(via: String, citta: String){
        this.via = via;
        this.citta = citta;
    }

    stampaIndirizzo() : String {
        return `Indirizzo ${this.via} ${this.citta}`
    }
}


class Persona{
    private nominativo: String | undefined;
    private ind : Indirizzo | undefined;

    constructor(nominativo?: String, via: String = "N.D.", citta: String = "N.D."){
        this.nominativo = nominativo;
        this.ind = new Indirizzo(via, citta);
    }

    stampaDettaglio() : String {
        return this.metodoPersonalizzato();
    }

    private metodoPersonalizzato() : String {
        return `Ciao: ${this.nominativo} ${this.ind?.stampaIndirizzo()}`;
    }
}

export default Persona;