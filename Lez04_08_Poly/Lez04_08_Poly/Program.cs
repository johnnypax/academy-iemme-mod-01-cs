using Lez04_08_Poly.Classes;

namespace Lez04_08_Poly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona stuUno = new Studente("Giovanni", "Pace", "AB1234");
            Persona stuDue = new Studente("Valeria", "Verdi", "AB1235");

            Persona docUno = new Docente("Mario", "Rossi", "Fisica", "Fisica");
            Persona docDue = new Docente("Marika", "Mariko", "Ingegneria", "Matematica");

            List<Persona> elenco = new List<Persona>();
            elenco.Add(stuUno);
            elenco.Add(stuDue);
            elenco.Add(docUno);
            elenco.Add(docDue);

            for (int i = 0; i < elenco.Count; i++)
            {
                //elenco[i].stampaDettaglio();

                if (elenco[i].GetType() == typeof(Studente))
                {
                    Studente temp = (Studente)elenco[i];
                    temp.stampaStudentePersonalizzato();
                }
                else if (elenco[i].GetType() == typeof(Docente))
                {
                    Docente temp = (Docente)elenco[i];
                    temp.stampaDocentePersonalizzato();
                }
            }

            //-------------- CASO LIMITE... NO BUONO ------------------------------

            //Object stuUno = new Studente("Giovanni", "Pace", "AB1234");
            //Object stuDue = new Studente("Valeria", "Verdi", "AB1235");

            //Object docUno = new Docente("Mario", "Rossi", "Fisica", "Fisica");
            //Object docDue = new Docente("Marika", "Mariko", "Ingegneria", "Matematica");

            //List<Object> elenco = new List<Object>();
            //elenco.Add(stuUno);
            //elenco.Add(stuDue);
            //elenco.Add(docUno);
            //elenco.Add(docDue);
            //elenco.Add("Ciao");
            //elenco.Add(12);
            //elenco.Add(12);



        }
    }
}