using System.Text.Json.Serialization;

namespace ASP_07_CorrezioneTask.Models
{
    public class OggettoSistema
    {
        [JsonIgnore]
        public Sistema sis { get; set; } = null!;
        public Oggetto ogg { get; set; } = null!;

        [JsonIgnore]
        public int SistemaRIF { get; set; }
        public int OggettoRIF { get; set; }
    }
}
