using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez04_scuola.Models
{
    internal class Docente : Persona
    {
        public string? Dipartimento { get; set; }

        //void Docente(string, string, string, string)
        public Docente(string? Nominativo, string? Email, string? Telefono, string? Dipartimento)
        {
            this.Nominativo = Nominativo;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Dipartimento = Dipartimento;
        }
        //void Docente(int, string, strina, string, string)
        public Docente(int Id, string? Nominativo, string? Email, string? Telefono, string? Dipartimento)
        {
            this.Id = Id;
            this.Nominativo = Nominativo;
            this.Email = Email;
            this.Telefono = Telefono;
            this.Dipartimento = Dipartimento;
        }
    }
}
