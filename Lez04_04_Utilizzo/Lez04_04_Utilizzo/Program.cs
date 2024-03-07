namespace Lez04_04_Utilizzo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Indirizzo indi = new Indirizzo()
            //{
            //    Via = "Via le mani dal naso",
            //    Cap = "11111",
            //    Citta = "Farindola",
            //    Provincia = "CH"
            //};

            //Utente gio = new Utente()
            //{
            //    Nominativo = "Giovanni Pace",
            //    Spedizione = indi
            //};

            //----------------------------------------------

            Utente gio = new Utente()
            {
                Nominativo = "Giovanni Pace",
                Spedizione = new Indirizzo()
                {
                    Via = "Via le mani dal naso",
                    Cap = "11111",
                    Citta = "Farindola",
                    Provincia = "CH"
                },
                Fatturazione = new Indirizzo()
                {
                    Via = "Piazza la bomba e scappa",
                    Cap = "85966",
                    Citta = "Roccacannuccia",
                    Provincia = "CH"
                }
            };

            Console.WriteLine(gio);

            /**
			 * Creare un sistema in grado di immagazinare i dati relativi ad una persona.
			 * Inoltre, sarà necessario immagazinare, all'interno di una persona, i dati 
			 * relativi a:
			 * - Codice Fiscale
			 * |- CODICE
			 * |_ Data di scadenza
			 * 
			 * - Carta di Identita: 
			 * |- CODICE
			 * |- Data di Emissione
			 * |- Data di Scadenza
			 * |_ Emissione (comune || zecca dello stato)
			 */

        }
    }
}