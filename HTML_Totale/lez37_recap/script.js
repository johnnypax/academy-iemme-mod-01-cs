// let saluta = "Hello world";
// saluta = "Saluta Andonio";

// let intero = 12334;
// let float = 123.23;

// let booleano = true;

// let prova = null;
// let provaDue = undefined;

// if(provaDue)
//     console.log("caso positivo")
// else
//     console.log("caso negativo")

//--------------------------------------
// let persona = {
//     nome: "Giovanni"
// }

// console.log(persona)

// let personaDue = new Object();
// personaDue.nome = "Giovanni";

// console.log(personaDue);
//--------------------------------------

// Alt + 9 + 6

// function saluta(varNome){
//     return `Ciao, come va ${varNome}?`;
// }

// console.log( saluta("Giovanni") );
// console.log( saluta("Valeria") );
// console.log( saluta("Marika") );
// console.log( saluta( {nome: "Giovanni"} ) );

//--------------------------------------

// let oggi = new Date();
// console.log(oggi)

// let insieme = new Set([1, 2, 3, 4, 1, "Lamborghini", {nome: "Giovanni"}]);
// console.log(insieme)

//--------------------------------------

// let equivalenteHashTable = new Map();

// equivalenteHashTable.set("chiave uno", "Giovanni");
// equivalenteHashTable.set("chiave due", 52);
// equivalenteHashTable.set("chiave tre", {nome: "Giovanni"});
// equivalenteHashTable.set({nome: "Marika"}, {giardino: false});


// // console.log(equivalenteHashTable.delete("chiave uno"));
// // console.log(equivalenteHashTable.delete("chiave uno"));

// console.log(equivalenteHashTable.size);

// let automobili = ["Lamborghini", "Maserati", "Koningsen", "FIAT"];
// console.log(automobili.length)

//--------------------------------------

// let mappa = new Map(
//     [
//         ["chiave 1", "valore 1"],
//         ["chiave 2", "valore 2"],
//         ["chiave 3", "valore 3"],
//     ]
// );

// for(let chiave of mappa.keys()){
//     console.log(chiave)
// }

// for(let valore of mappa.values()){
//     console.log(valore)
// }

// mappa.forEach((valore, chiave) => {
//     console.log(chiave, valore)
// })

//--------------------------------------

// let elenco = [1, 2, 3, 4, 5];

// // let quadrati = elenco.map(
// //     function(elem){
// //         return elem * elem
// //     }
// // )

// let quadrati = elenco.map(elem => elem * elem)

// console.log(elenco);
// console.log(quadrati);

//--------------------------------------

// const persone = [
//     { nome: "Mario", cognome: "Rossi" },
//     { nome: "Luigi", cognome: "Bianchi" },
//     { nome: "Anna", cognome: "Verdi" }
// ];

// const elenco = persone.map(p => `${p.nome} ${p.cognome}`);

// console.log(persone);
// console.log(elenco);

//--------------------------------------

const persone = [
    { nome: "Mario", cognome: "Rossi" },
    { nome: "Luigi", cognome: "Bianchi", eta: 24 },
    { nome: "Anna", cognome: "Verdi" }
];

const indVal = persone.map((valore, indice) => `Indice ${indice + 1}, valore: ${valore.nome}`)

console.log(indVal)