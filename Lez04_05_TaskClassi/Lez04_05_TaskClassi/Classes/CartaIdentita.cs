using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lez04_05_TaskClassi.Classes
{
    internal class CartaIdentita : CodiceFiscale
    {
        public DateTime DataEmissione { get; set; }

		private string? luogoEmissione;

		public string? LuogoEmissione
		{
			get { return luogoEmissione; }
			set {
				if (value is not null && (value.Equals("Comune") || value.Equals("Zecca dello stato")))
					luogoEmissione = value;
				else
					Console.WriteLine("ERRORE DI EMISSIONE");
			}
		}

		public override string ToString()
		{
			return $"[CARTAIDENTITA] {Codice} {DataScadenza.ToString("dd/MM/yyyy")} {DataEmissione.ToString("dd/MM/yyyy")} {LuogoEmissione}";
		}

	}
}
