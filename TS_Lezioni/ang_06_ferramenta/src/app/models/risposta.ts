import { Prodotto } from "./prodotto";

export class Risposta {
    status: string | undefined;
    data?: string | Prodotto | Prodotto[] | undefined | null
}
