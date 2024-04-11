import { Prodotto } from "./prodotto"

export class Status {
    status: string | undefined;
    data: undefined | string | Prodotto | Prodotto[] | null;
}
