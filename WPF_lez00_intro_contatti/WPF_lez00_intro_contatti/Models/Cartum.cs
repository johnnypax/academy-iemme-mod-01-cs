using System;
using System.Collections.Generic;

namespace WPF_lez00_intro_contatti.Models;

public partial class Cartum
{
    public int CartaId { get; set; }

    public string Codice { get; set; } = null!;

    public string Negozio { get; set; } = null!;

    public int PersonaRif { get; set; }

    public virtual Persona PersonaRifNavigation { get; set; } = null!;
}
