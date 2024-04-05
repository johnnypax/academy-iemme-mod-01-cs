namespace ASP_07_CorrezioneTask.Models
{
    public class Oggetto
    {
        public int OggettoID { get; set; }
        public string? Nome { get; set; }

        public IEnumerable<OggettoSistema> ElencoOggSis { get; set; } = new List<OggettoSistema>();
    }
}
