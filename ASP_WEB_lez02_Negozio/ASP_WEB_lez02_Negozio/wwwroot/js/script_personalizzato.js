function elimina(varCodice) {
    $.ajax(
        {
            url: "/Prodotto/elimina/" + varCodice,
            type: "DELETE",
            success: function (risultato) {
                alert("STAPPOOOOOO");
                location.reload();
            },
            error: function (errore) {
                alert(errore)
            }
        }
    )
}