namespace ASP_07_CorrezioneTask.Models
{
    public class Sistema
    {
        public int SistemaID { get; set; }
        public string? Nome { get; set; }

        public IEnumerable<OggettoSistema> ElencoOggSis { get; set; } = new List<OggettoSistema>();
    }
}
