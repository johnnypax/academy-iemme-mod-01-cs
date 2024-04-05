let base_url = "https://localhost:7108/Prodotto/";

const stampaTabella = () => {
    $.ajax(
        {
            url: base_url + "nonfiltrati",
            type: "GET",
            success: function(risultato){
                if(risultato.status == "SUCCESS"){
                    let contenuto = "";
                    for(let [i,o] of risultato.data.entries()){
                        contenuto += `
                            <tr data-codice="${o.cod}">
                                <td>${o.nom}</td>
                                <td>${o.des}</td>
                                <td>${o.pre}</td>
                                <td>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <button type="button" class="btn btn-primary btn-block" onclick="modificaQuan(this, false)">-</button>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <strong>${o.qua}</strong>
                                        </div>
                                        <div class="col-md-4">
                                            <button type="button" class="btn btn-primary btn-block" onclick="modificaQuan(this, true)">+</button>
                                        </div>
                                    </div>
                                </td>
                                <td>${o.cat}</td>
                                <td>
                                    <button type="button" class="btn btn-primary" onclick="elimina(this)">Elimina</button>
                                </td>
                            </tr>
                        `
                    }
                    $("#corpo-tabella").html(contenuto);
                }
                else
                    alert("ERRORE di reperimento dati");
            },
            error: function(errore){
                alert("ERRORE");
                console.log(risultato)
            }
        }
    );
}


const ricercaTabella = (varQuery) => {
    $.ajax(
        {
            url: base_url + "ricerca",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify({ Contenuto: varQuery }),
            success: function(risultato){
                if(risultato.status == "SUCCESS"){
                    let contenuto = "";
                    for(let [i,o] of risultato.data.entries()){
                        contenuto += `
                            <tr data-codice="${o.cod}">
                                <td>${o.nom}</td>
                                <td>${o.des}</td>
                                <td>${o.pre}</td>
                                <td>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <button type="button" class="btn btn-primary btn-block" onclick="modificaQuan(this, false)">-</button>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <strong>${o.qua}</strong>
                                        </div>
                                        <div class="col-md-4">
                                            <button type="button" class="btn btn-primary btn-block" onclick="modificaQuan(this, true)">+</button>
                                        </div>
                                    </div>
                                </td>
                                <td>${o.cat}</td>
                                <td>
                                    <button type="button" class="btn btn-primary" onclick="elimina(this)">Elimina</button>
                                </td>
                            </tr>
                        `
                    }
                    $("#corpo-tabella").html(contenuto);
                }
                else
                    alert("ERRORE di reperimento dati");
            },
            error: function(errore){
                alert("ERRORE");
                console.log(risultato)
            }
        }
    );
}

//varModalita: true se incremento, false se decremento
const modificaQuan = (varElemento, varModalita) => {
    let codice = $(varElemento).closest("tr").data("codice");

    $.ajax(
        {
            url: `${base_url}quantita/${codice}/${varModalita ? 'incremento' : 'decremento'}`,
            type: "GET",
            success: function(risultato){
                switch(risultato.status){
                    case "SUCCESS":
                        stampaTabella();
                        break;
                    case "ERROR":
                        alert(risultato.data);
                        break;
                }
            },
            error: function(error){
                alert("Errore");
                console.log(errore)
            }
        }
    );
}

const elimina = (varElemento) => {
    let codice = $(varElemento).parent().parent().data("codice");

    // let codice = $(varElemento).data("codice");

    $.ajax(
        {
            url: base_url + "elimina/" + codice,
            type: "DELETE",
            success: function(risultato){
                switch(risultato.status){
                    case "SUCCESS":
                        alert("Ok");
                        stampaTabella();
                        break;
                    case "ERROR":
                        alert(risultato.data);
                        break;
                }
            },
            error: function(errore){
                alert("ERRORE");
                console.log(errore)
            }
        }
    );
}

$(document).ready(
    function(){
        stampaTabella();

        // $("#ricerca").on("click", function(){
        //     let query = $("input[name=input-ricerca]").val();

        //     ricercaTabella(query)
        // });

        $("input[name=input-ricerca]").on('keyup', function(){
            let query = $(this).val()

            ricercaTabella(query)
        })

    }
);