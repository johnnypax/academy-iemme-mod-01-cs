using ASP_Mongo_lez01.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace ASP_Mongo_lez01.Repos
{
    public class AziendaRepository: IRepo<Impiegato>
    {
        private IMongoCollection<Impiegato> impiegati;
        private readonly ILogger _logger;

        public AziendaRepository(IConfiguration configuration, ILogger<AziendaRepository> logger)
        {
            this._logger = logger;

            string? connessioneLocale = configuration.GetValue<string>("MongoDbSettings:Locale");
            string? databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.impiegati = _database.GetCollection<Impiegato>("Impiegatos");

        }

        public bool Delete(Impiegato item)
        {
            try
            {
                this.impiegati.DeleteOne<Impiegato>(i => i.Matricola == item.Matricola);

                _logger.LogInformation("Eliminazione effettuata con successo");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public Impiegato Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Impiegato> GetAll()
        {
            //List<Impiegato> elenco = impiegati.AsQueryable().ToList();
            return impiegati.Find(p => true).ToList();
        }

        public bool Insert(Impiegato item)
        {
            try
            {
                if (impiegati.Find(i => i.Matricola == item.Matricola).ToList().Count > 0)
                    return false;

                impiegati.InsertOne(item);
                _logger.LogInformation("Inserimento effettuato con successo");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public bool Update(Impiegato item)
        {
            Impiegato? temp = GetByMatricola(item.Matricola);
            if(temp != null)
            {
                temp.Nominativo = item.Nominativo != null ? item.Nominativo : temp.Nominativo;
                temp.Dipartimento = item.Dipartimento != null ? item.Dipartimento : temp.Dipartimento;
                temp.DataAssunzione = item.DataAssunzione.Equals(TimeSpan.MinValue) ? item.DataAssunzione : temp.DataAssunzione;

                var filter = Builders<Impiegato>.Filter.Eq(i => i.Id, temp.Id);
                try
                {
                    impiegati.ReplaceOne(filter, temp);
                    return true;
                }
                catch (Exception ex){ 
                    _logger.LogError(ex.Message);
                }
            }

            return false;
        }

        public Impiegato? GetByMatricola(string? varMatr)
        {
            try
            {
                return impiegati.Find(i => i.Matricola == varMatr).ToList()[0];
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
