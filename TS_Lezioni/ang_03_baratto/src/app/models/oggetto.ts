import { Persona } from "./persona";

export class Oggetto {
    codice: string | undefined;
    nome: string | undefined;
    descrizione?: string;
    proprietario: Persona | undefined;
}
