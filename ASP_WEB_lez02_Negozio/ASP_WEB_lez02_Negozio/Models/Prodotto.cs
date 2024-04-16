using System;
using System.Collections.Generic;

namespace ASP_WEB_lez02_Negozio.Models;

public partial class Prodotto
{
    public int ProdottoId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descrizione { get; set; }

    public string? Categoria { get; set; }

    public string Codice { get; set; } = null!;

    public decimal? Prezzo { get; set; }

    public DateOnly? DataScadenza { get; set; }

    public DateTime? DataInserimento { get; set; }
}
