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
}, 1000);

stampa(); 