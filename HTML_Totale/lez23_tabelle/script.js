let elencoUno = ["Giovanni", "Mario", "Valeria", "Marika"];
elencoUno.push("Pippo")

// elencoUno.forEach(element => {
//     console.log(element)
// });

let contenuto = "";

for(let i=0; i<elencoUno.length; i++){
    contenuto += `
        <tr>
            <td>${elencoUno[i]}</td>
        </tr>
    `
}

document.getElementById("corpo-tabella").innerHTML = contenuto;