abstract class Animale{
    hasPelo: boolean = false;

    abstract versoEmesso(): void;

    dormi(): void{
        console.log("zzzzZZZZZ***")
    }
}

class Gatto extends Animale{
    versoEmesso(): void {
        console.log("Miau miau")
    }
}

let bu = new Gatto();
bu.versoEmesso();
bu.dormi();

// let ciccio = new Animale();