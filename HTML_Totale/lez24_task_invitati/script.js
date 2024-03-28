let contenuto = "";
let i = 0;

function aggiungi(){
    let nome = document.getElementById("input-nome").value;
    let cognome = document.getElementById("input-cognome").value;
    let telefono = document.getElementById("input-telefono").value;

    contenuto += `
        <tr>
            <td>${i + 1}</td>
            <td>${nome}</td>
            <td>${cognome}</td>
            <td>${telefono}</td>
        </tr>
    `

    i++;

    document.getElementById("corpo-tabella").innerHTML = contenuto

    document.getElementById("input-nome").value = "";
    document.getElementById("input-cognome").value = "";
    document.getElementById("input-telefono").value = "";
}