import { Oggetto } from "./Oggetto"

/**
 * statoProposta: pending | accepted | rejected
 */
export class Proposta{
    oggProp: Oggetto;
    oggRich: Oggetto;
    statoProposta: string = "pending";
}