using DB_lez06_ef_introduzione.Models;

namespace DB_lez06_ef_introduzione
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Scaffold-DbContext "Server=BOOK-N57JVKH6HJ\SQLEXPRESS;Database=acc_lez07_otm_carta;User Id=academy;Password=academy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            */

            //Persona osv = new Persona()
            //{
            //    Nome = "Osvaldo",
            //    Cognome = "Bevilacqua",
            //    Email = "osv@wtr.com"
            //};

            //Cartum carUno = new Cartum()
            //{
            //    Codice = "GG123",
            //    Negozio = "SMA",
            //    PersonaRifNavigation = osv,
            //};

            //Cartum carDue = new Cartum()
            //{
            //    Codice = "TT009",
            //    Negozio = "Tigotà",
            //    PersonaRifNavigation = osv,
            //};

            //using (var ctx = new AccLez07OtmCartaContext())
            //{
            //    try
            //    {
            //        ctx.Personas.Add(osv);
            //        ctx.Carta.Add(carUno);
            //        ctx.Carta.Add(carDue);
            //        ctx.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            ICollection<Persona> prova = new List<Persona>();

            using (var ctx = new AccLez07OtmCartaContext())
            {
                //ICollection<Persona> elencoPer = ctx.Personas.ToList();

                try
                {
                    Persona perTemp = ctx.Personas.Single(p => p.PersonaId == 4);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                //ICollection<Cartum> ricercaCarta = ctx.Carta.Where(c => c.Negozio == "Coop").ToList();
                //foreach (Cartum c in ricercaCarta)
                //{
                //    Console.WriteLine(c.PersonaRifNavigation.Nome);
                //}

                //DATO L'Esempio: acc_lez09_mtm_universita, voglio l'elenco di tutti gli esami a cui è iscritto uno specifico studente
                //E l'elenco di tutti gli studenti iscritti ad un esame

                IEnumerable<Persona> elencoUno = new List<Persona>();
                ICollection<Persona> elencoDue = new List<Persona>();
                IList<Persona> elencoTre = new List<Persona>();

            }
        }
    }
}
