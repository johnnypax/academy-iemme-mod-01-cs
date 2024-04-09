class Conto{
    private saldo: number;

    constructor(saldoIniziale: number){
        this.saldo = saldoIniziale;
    }

    deposita(importo: number): boolean{
        if(importo > 0){
            this.saldo += importo;
            return true;
        }

        return false;
    }

    preleva(importo: number): boolean{
        if(importo > 0 && importo <= this.saldo){
            this.saldo -= importo;
            return true;
        }

        return false;
    }

    getSaldo(): number{
        return this.saldo;
    }
}

let mioConto = new Conto(1000);
// console.log(mioConto.preleva(1500) ? "OK" : "ERRORE");
// console.log(mioConto.getSaldo())

console.log(mioConto)