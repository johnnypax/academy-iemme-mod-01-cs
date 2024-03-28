function aggiungi(){
    let varNome = document.getElementById("input-nome").value;
    let varCognome = document.getElementById("input-cognome").value;
    let varMatricola = document.getElementById("input-matricola").value;

    let stud = {
        nome: varNome,
        cognome: varCognome,
        matricola: varMatricola
    }

    elenco.push(stud);

    //STAMPO ARRAY
    stampa();    
}

function stampa(){
    let contenuto = "";
    for(let [idx, item] of elenco.entries()){
        contenuto += `
            <tr>
                <td>${idx + 1}</td>
                <td>${item.nome}</td>
                <td>${item.cognome}</td>
                <td>${item.matricola ? item.matricola : "n.d."}</td>
                <td>
                    <button type="button" class="btn btn-danger" onclick="elimina(${idx})">Elimina</button>
                </td>
            </tr>
        `;
    }
    document.getElementById("corpo-tabella").innerHTML = contenuto;
}

function elimina(varIdx){
    elenco.splice(varIdx, 1)

    stampa();
}

//MAIN
let elenco = [
    {
        nome: "Giovanni",
        cognome: "Pace",
    },
    {
        nome: "Valeria",
        cognome: "Verdi",
        matricola: "AB12346"
    },
    {
        nome: "Mario",
        cognome: "Rossi",
        matricola: "AB12347"
    }
];

stampa();
