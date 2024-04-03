const stampaTabella = () => {
    $.ajax(
        {
            url: "https://localhost:7071/api/libri",
            type: "GET",
            success: function(risultato){
                let contenuto = "";

                for(let [idx, item] of risultato.entries()){
                    contenuto += `
                        <tr>
                            <td>${item.titolo}</td>
                            <td>${item.autore}</td>
                            <td>${item.descrizione}</td>
                            <td>${item.prezzo}</td>
                            <td>${item.quantita}</td>
                            <td>
                                <button class="btn btn-danger" onclick="elimina('${item.codice}')">Elimina</button>
                            </td>
                        </tr>
                    `;
                }

                $("#corpo-tabella").html(contenuto);
            }, 
            error: function(errore){
                alert("ERRORE");
                console.log(errore)
            }
        }
    );
}

const elimina = (codice) => {
    
    $.ajax(
        {
            url: "https://localhost:7071/api/libri/codice/" + codice,
            type: "POST",
            success: function(){
                alert("Stappooooo");
                stampaTabella();
            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
        }
    )

}

const salvaElemento = () => {
    let tito = $("#input-titolo").val();
    let auto = $("#input-autore").val();
    let desc = $("#input-descrizione").val();
    let prez = $("#input-prezzo").val();
    let quan = $("#input-quantita").val();

    $.ajax(
        {
            url: "https://localhost:7071/api/libri",
            type: "POST",
            data: JSON.stringify({
                titolo: tito,
                autore: auto,
                descrizione: desc,
                prezzo: prez,
                quantita: quan
            }),
            contentType: "application/json",
            dataType: "json",
            success: function(){
                alert("Stappooooo");
                stampaTabella();
            },
            error: function(errore){
                alert("Errore");
                console.log(errore);
            }
        
        }
    )
}

$(document).ready(
    function(){

        stampaTabella();

        $(".salva").on("click", () => {
            salvaElemento();
        })

    }
);