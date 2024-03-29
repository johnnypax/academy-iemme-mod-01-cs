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
                <td class="text-right">
                    <button class="btn btn-outline-warning" onclick="modifica(${idx})">
                        <i class="fa-solid fa-pencil"></i>
                    </button>
                    <button class="btn btn-outline-danger" onclick="elimina(${idx})">
                        <i class="fa-solid fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;
    }

    document.getElementById("corpo-tabella").innerHTML = stringaTabella;
}

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

    $("#modaleInserimento").modal("hide");
}

const elimina = (indice) => {
    let elenco = JSON.parse( localStorage.getItem('oggetti_amz') );
    elenco.splice(indice, 1);
    localStorage.setItem('oggetti_amz', JSON.stringify(elenco));

    stampa();
}

const modifica = (indice) => {

    let elenco = JSON.parse( localStorage.getItem('oggetti_amz') );
    console.log(elenco[indice])

    document.getElementById("update-nome").value = elenco[indice].nome;
    document.getElementById("update-descrizione").value = elenco[indice].desc;
    document.getElementById("update-prezzo").value = elenco[indice].prez;
    document.getElementById("update-categoria").value = elenco[indice].cate;

    $("#modaleModifica").data("identificativo", indice)

    $("#modaleModifica").modal("show");
}

const update = () => {
    let nome = document.getElementById("update-nome").value;
    let desc = document.getElementById("update-descrizione").value;
    let prez = document.getElementById("update-prezzo").value;
    let cate = document.getElementById("update-categoria").value;

    let ogg = {
        nome,
        desc,
        prez,
        cate
    }

    let indice = $("#modaleModifica").data("identificativo")

    let elenco = JSON.parse( localStorage.getItem('oggetti_amz') );
    elenco[indice] = ogg;
    localStorage.setItem('oggetti_amz', JSON.stringify(elenco));

    $("#modaleModifica").modal("hide");
}


//Creazione elenco se non esiste
let elencoString = localStorage.getItem('oggetti_amz');
if(!elencoString)
    localStorage.setItem('oggetti_amz', JSON.stringify([]) );

setInterval(() => {
    stampa(); 
}, 1000);

stampa(); 