import { Oggetto } from "./oggetto";

export class Persona{
    codice: string | undefined;
    nominativo: string | undefined;
    listaOgg: Oggetto[] = new Array();

    constructor(nominativo?: string){
        this.nominativo = nominativo;
        this.codice = `${new Date().getTime()}`;
    }
}
