import { Utente } from "./utente";

export class Oggetto{
    codice: string;
    nome: string;
    descrizione?: string;
    proprietario: Utente;
}