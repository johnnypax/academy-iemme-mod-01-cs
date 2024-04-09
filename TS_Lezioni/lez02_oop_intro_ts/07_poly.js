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
var Persona = /** @class */ (function () {
    function Persona(varNom) {
        this.nominativo = varNom;
    }
    return Persona;
}());
var Studente = /** @class */ (function (_super) {
    __extends(Studente, _super);
    function Studente(varMatr, varNominativo) {
        var _this = _super.call(this, varNominativo) || this;
        _this.matricola = varMatr;
        return _this;
    }
    return Studente;
}(Persona));
var Docente = /** @class */ (function (_super) {
    __extends(Docente, _super);
    function Docente() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Docente;
}(Persona));
var Segretario = /** @class */ (function (_super) {
    __extends(Segretario, _super);
    function Segretario() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Segretario;
}(Persona));
var stuUno = new Studente("Giovanni");
var studDue = new Studente("Mario", "AB1234");
var studTre = new Studente("Valeria", null);
