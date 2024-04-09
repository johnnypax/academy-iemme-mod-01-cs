var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Automobile = /** @class */ (function () {
    function Automobile(varMarca, varModello) {
        this.marca = varMarca;
        this.modello = varModello;
    }
    Automobile.prototype.stampaDettaglio = function () {
        console.log("Automobile: ".concat(this.marca, " ").concat(this.modello));
    };
    return Automobile;
}());
var Autoelettrica = /** @class */ (function (_super) {
    __extends(Autoelettrica, _super);
    function Autoelettrica(varMarca, varModello, varAutonomia) {
        var _this = _super.call(this, varMarca, varModello) || this;
        _this.autonomia = varAutonomia;
        return _this;
    }
    Autoelettrica.prototype.stampaDettaglio = function () {
        console.log("Automobile Elettrica: ".concat(this.marca, " ").concat(this.modello, " ").concat(this.autonomia));
    };
    return Autoelettrica;
}(Automobile));
var automobUno = new Automobile("Lexus", "Da corsa");
automobUno.stampaDettaglio();
var autoDue = new Autoelettrica("Tesla", "Auto guida autonoma", 400);
autoDue.stampaDettaglio();
