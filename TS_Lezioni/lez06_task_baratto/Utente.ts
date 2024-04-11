import { Oggetto } from "./Oggetto";

export class Utente{
    codice: string | undefined;
    nominativo: string | undefined;
    listaOgg: Oggetto[] = new Array();
}

