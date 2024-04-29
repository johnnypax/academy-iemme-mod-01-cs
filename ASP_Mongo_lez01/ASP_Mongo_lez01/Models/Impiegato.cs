using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP_Mongo_lez01.Models
{
    public class Impiegato
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("nomi")]
        public string? Nominativo { get; set; }

        [BsonElement("matr")]
        public string? Matricola { get; set; }

        [BsonElement("dipa")]
        public string? Dipartimento { get; set; }

        [BsonElement("assu")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime DataAssunzione { get; set; }
    }
}
