const salva = () => {
    let nome = document.getElementById("input-nome").value;
    let desc = document.getElementById("input-descrizione").value;
    let prez = document.getElementById("input-prezzo").value;
    let cate = document.getElementById("select-categoria").value;

    let ogg = {
        nome,
        desc,
        prez,
        cate
    }

    let elenco = JSON.parse( localStorage.getItem('oggetti_amz') ); //Prendo il vecchio elenco decodificato sotto forma di oggetto
    elenco.push(ogg);                                               //Aggiungo l'elemento al vecchio elenco
    localStorage.setItem('oggetti_amz', JSON.stringify(elenco));    //Ricodifico l'elenco (sotto forma di stringa) per poterlo salvare nel Local Storage

    document.getElementById("input-nome").value = "";
    document.getElementById("input-descrizione").value = "";
    document.getElementById("input-prezzo").value = "";
    document.getElementById("select-categoria").value = "";

    stampa();
}

const stampa = () => {
    let elenco = JSON.parse( localStorage.getItem('oggetti_amz') );

    let stringaTabella = '';
    for(let [idx, item] of elenco.entries()){
        stringaTabella += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.nome}</td>
                <td>${item.desc}</td>
                <td>${item.prez}</td>
                <td>${item.cate}</td>
            </tr>
        `;
    }

    document.getElementById("corpo-tabella").innerHTML = stringaTabella;
}




//Creazione elenco se non esiste
let elencoString = localStorage.getItem('oggetti_amz');
if(!elencoString)
    localStorage.setItem('oggetti_amz', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 2000);