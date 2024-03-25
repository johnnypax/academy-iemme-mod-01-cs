using System;
using System.Collections.Generic;

namespace WPF_lez05_task_eventi.Models;

public partial class Partecipante
{
    public int PartecipanteId { get; set; }

    public string Nome { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public virtual ICollection<Evento> EventoRifs { get; set; } = new List<Evento>();
}
