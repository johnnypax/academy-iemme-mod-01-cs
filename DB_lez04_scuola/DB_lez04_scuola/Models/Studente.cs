using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez04_scuola.Models
{
    internal class Studente : Persona
    {
        public string? Matricola { get; set; }

        public Studente()
        {

        }
        public Studente(string? Nominativo, string? Email, string? Telefono, string? Matricola)
        {
            this.Nominativo = Nominativo;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Matricola = Matricola;
        }
        public Studente(int Id, string? Nominativo, string? Email, string? Telefono, string? Matricola)
        {
            this.Id = Id;
            this.Nominativo = Nominativo;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Matricola = Matricola;
        }
    }
}
