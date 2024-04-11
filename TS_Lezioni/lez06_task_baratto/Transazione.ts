import { Proposta } from "./Proposta";
import { v4 as uuidv4 } from 'uuid';

export class Transazione{
    codice: string = uuidv4();
    data: Date = new Date();
    proposta: Proposta;
}