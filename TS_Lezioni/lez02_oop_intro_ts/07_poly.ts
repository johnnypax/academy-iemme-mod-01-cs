abstract class Persona{
    private nominativo: String | undefined | null;

    constructor(varNom?: String | null){
        this.nominativo = varNom
    }
}

class Studente extends Persona{
    private matricola: String | undefined | null;

    constructor(varMatr?: String, varNominativo?: String | null){
        super(varNominativo);
        this.matricola = varMatr;
    }
}

class Docente extends Persona{
    
}

class Segretario extends Persona{

}

let stuUno = new Studente(undefined, "AB1236");
let studDue = new Studente("AB1234", "Mario");
let studTre = new Studente("Valeria");

let studQuat = new Studente();