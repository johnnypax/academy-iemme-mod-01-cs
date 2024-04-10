// const somma = (numUno: number, numDue: number): number => {
//     return numUno + numDue;
// } 

// let uno : Number = 5;
// let due : number = 6;

// console.log(uno);
// console.log(due);

//------------------------------------------

//Saluta(String, String)
//Saluta(String, String, String)
/**
 * Funzione saluta
 * @param varNome Nome della persona
 * @param varCognome Cognome della persona
 * @param varTitolo Titolo della persona | undefined
 */
// const saluta = (varNome: String, varCognome: String, varTitolo?: String) => {
//     if(varTitolo)
//         console.log(`Ciao ${varTitolo} ${varNome} ${varCognome}`)
//     else
//         console.log(`Ciao ${varNome} ${varCognome}`)
// }

// saluta("GIovani", "Pace")

//------------------------------------------------------

const saluta = (varNome: String, varCognome: String, varTitolo: String | null = "N.D.") => {
    console.log(`Ciao ${varTitolo} ${varNome} ${varCognome}`)
}
    
saluta("GIovani", "Pace")
saluta("Valeria", "Verdi", "Sig.ra")
saluta("Valeria", "Verdi", null)