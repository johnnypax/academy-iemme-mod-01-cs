using System;
using System.Collections.Generic;

namespace WPF_lez05_task_eventi.Models;

public partial class Evento
{
    public int EventoId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public DateTime DataEvento { get; set; }

    public string Luogo { get; set; } = null!;

    public int CapMax { get; set; }

    public virtual ICollection<Risorsa> Risorsas { get; set; } = new List<Risorsa>();

    public virtual ICollection<Partecipante> PartecipanteRifs { get; set; } = new List<Partecipante>();
}
