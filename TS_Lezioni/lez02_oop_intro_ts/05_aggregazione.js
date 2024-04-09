var Ruota = /** @class */ (function () {
    function Ruota(varDia) {
        this.diametro = varDia;
    }
    Ruota.prototype.stampaDet = function () {
        return "Ruota: ".concat(this.diametro);
    };
    return Ruota;
}());
var Auto = /** @class */ (function () {
    function Auto() {
        this.ruote = new Array(); // []
    }
    Auto.prototype.setMarca = function (varMarca) {
        this.marca = varMarca;
    };
    Auto.prototype.getMarca = function () {
        return this.marca;
    };
    Auto.prototype.addRuota = function (objRuota) {
        this.ruote.push(objRuota);
    };
    Auto.prototype.stampaDet = function () {
        console.log("Automobile: ".concat(this.marca));
        this.ruote.forEach(function (element) {
            console.log(element.stampaDet());
        });
    };
    return Auto;
}());
var au = new Auto();
au.setMarca("Audi");
au.addRuota(new Ruota(16));
au.addRuota(new Ruota(16));
au.addRuota(new Ruota(16));
au.addRuota(new Ruota(16));
au.stampaDet();
