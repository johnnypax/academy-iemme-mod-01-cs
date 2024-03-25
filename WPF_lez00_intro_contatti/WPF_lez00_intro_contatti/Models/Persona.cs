using System;
using System.Collections.Generic;

namespace WPF_lez00_intro_contatti.Models;

public partial class Persona
{
    public int PersonaId { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Cartum> Carta { get; set; } = new List<Cartum>();
}
