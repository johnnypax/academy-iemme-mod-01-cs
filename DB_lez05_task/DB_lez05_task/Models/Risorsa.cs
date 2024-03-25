using System;
using System.Collections.Generic;

namespace DB_lez05_task.Models;

public partial class Risorsa
{
    public int RisorsaId { get; set; }

    public string Tipo { get; set; } = null!;

    public int Quantita { get; set; }

    public int Costo { get; set; }

    public string? Fornitore { get; set; }

    public int EventoRif { get; set; }

    public virtual Evento EventoRifNavigation { get; set; } = null!;
}
