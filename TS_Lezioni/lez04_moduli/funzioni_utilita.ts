function calcolaDataOggi(): Date{
    return new Date();
}

export function saluta(varNome: String) : String{
    return `Ciao, ${varNome} ${calcolaDataOggi()}`;
}

export function somma(numUno: number, numDue: number): number {
    return numUno + numDue;
} 

// export {saluta, somma}