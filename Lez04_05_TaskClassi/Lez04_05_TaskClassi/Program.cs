using Lez04_05_TaskClassi.Classes;

namespace Lez04_05_TaskClassi
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

			Persona per = new Persona()
			{
				Nome = "Giovanni",
				Cognome = "Pace",
				Identita = new CartaIdentita()
				{
					Codice = "AB1234",
					DataEmissione = new DateTime(2020, 12, 01),
					DataScadenza = new DateTime(2022, 12, 01),
					LuogoEmissione = "Comune"
				}
			};

			Console.WriteLine(per);
        }
    }
}