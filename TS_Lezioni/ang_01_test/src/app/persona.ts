export class Persona {
    nome: string | undefined;
    cognome: string | undefined;
    eta: number | undefined;

    constructor(nome?: string, cognome?: string, eta?: number){
        this.nome = nome;
        this.cognome = cognome;
        this.eta = eta;
    }
}
