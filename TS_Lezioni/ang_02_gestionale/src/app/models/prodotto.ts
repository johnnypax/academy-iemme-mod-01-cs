export class Prodotto {
    codice: string | undefined;
    nome: string | undefined;
    descrizione: string | undefined;
    prezzo: number | undefined;

    constructor(codice?: string, nome?: string, descrizione?: string, prezzo: number = 0){
        this.codice = codice;
        this.nome = nome;
        this.descrizione = descrizione;
        this.prezzo = prezzo;
    }
}
