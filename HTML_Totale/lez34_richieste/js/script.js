$(document).ready(
    function(){

        // $(".lorem").hide();

        // $("#pulsante-premi").on('click', () => {
        //     $(".lorem").hide();
        // });

        console.log("Inizio programma");

        $.ajax(
            {
                url: "https://localhost:7071/api/libri",
                type: "GET",
                success: function(risultato){
                    console.log("SUCCESSO");
                    let lista = risultato

                    console.log(lista)
                }, 
                error: function(errore){
                    console.log("ERRORE");
                    console.log(errore)
                }
            }
        );

        
        console.log("Fine programma");
    }
);