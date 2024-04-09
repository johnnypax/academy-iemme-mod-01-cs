var Conto = /** @class */ (function () {
    function Conto(saldoIniziale) {
        this.saldo = saldoIniziale;
    }
    Conto.prototype.deposita = function (importo) {
        if (importo > 0) {
            this.saldo += importo;
            return true;
        }
        return false;
    };
    Conto.prototype.preleva = function (importo) {
        if (importo > 0 && importo <= this.saldo) {
            this.saldo -= importo;
            return true;
        }
        return false;
    };
    Conto.prototype.getSaldo = function () {
        return this.saldo;
    };
    return Conto;
}());
var mioConto = new Conto(1000);
// console.log(mioConto.preleva(1500) ? "OK" : "ERRORE");
// console.log(mioConto.getSaldo())
console.log(mioConto);
