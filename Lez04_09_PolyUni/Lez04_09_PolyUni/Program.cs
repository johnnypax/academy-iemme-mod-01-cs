using Lez04_09_PolyUni.Classes;

namespace Lez04_09_PolyUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Universita uni = new Universita()
            {
                Nome = "Dei ciccioli"
            };

            Persona stuUno = new Studente("Giovanni", "Pace", "AB1234");
            Persona stuDue = new Studente("Valeria", "Verdi", "AB1235");

            Persona docUno = new Docente("Mario", "Rossi", "Fisica", "Fisica");
            Persona docDue = new Docente("Marika", "Mariko", "Ingegneria", "Matematica");

            uni.aggiungi(stuUno);
            uni.aggiungi(stuDue);
            uni.aggiungi(docUno);
            uni.aggiungi(docDue);

            uni.elencoStudenti();

            //.....

            Universita uniDue = new Universita()
            {
                Nome = "Dei poppoli"
            };

            Persona stuTre = new Studente("Giggio", "Topo", "AB1232");

            uniDue.aggiungi(stuTre);
            uniDue.elenco
            uniDue.elencoStudenti();

        }
    }
}