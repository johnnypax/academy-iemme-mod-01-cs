abstract class Persona{
    private nominativo: String | undefined | null;

    constructor(nominativo?: String | null){
        this.nominativo = nominativo
    }
}

class Studente extends Persona{
    private matricola: String | undefined | null;

    constructor(matricola?: String, nominativo?: String | null){
        super(nominativo);
        this.matricola = matricola;
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