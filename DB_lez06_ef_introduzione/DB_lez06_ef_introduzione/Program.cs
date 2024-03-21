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

            Persona osv = new Persona()
            {
                Nome = "Osvaldo",
                Cognome = "Bevilacqua",
                Email = "osv@wtr.com"
            };

            Cartum carUno = new Cartum()
            {
                Codice = "GG123",
                Negozio = "SMA",
                PersonaRifNavigation = osv,
            };

            Cartum carDue = new Cartum()
            {
                Codice = "TT009",
                Negozio = "Tigotà",
                PersonaRifNavigation = osv,
            };

            using (var ctx = new AccLez07OtmCartaContext())
            {
                try
                {
                    ctx.Personas.Add(osv);
                    ctx.Carta.Add(carUno);
                    ctx.Carta.Add(carDue);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
