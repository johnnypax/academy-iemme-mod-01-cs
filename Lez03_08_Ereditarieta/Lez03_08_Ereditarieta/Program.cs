using Lez03_08_Ereditarieta.Classes;

namespace Lez03_08_Ereditarieta
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Persona per = new Persona("Giovanni", "Pace");
            per.stampaDettaglio();

            Studente stu = new Studente("Valeria", "Verdi", "AB1234");
            stu.stampaDettaglio();

            Docente doc = new Docente()
            {
                Nome = "Emmet",
                Cognome = "Brown",
                Materia = "Fisica applicata",
                Dipartimento = "Fisica"
            };

            doc.stampaDettaglio();
        }
    }
}