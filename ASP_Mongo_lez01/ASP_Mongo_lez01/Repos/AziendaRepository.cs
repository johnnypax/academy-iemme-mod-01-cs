using ASP_Mongo_lez01.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace ASP_Mongo_lez01.Repos
{
    public class AziendaRepository: IRepo<Impiegato>
    {
        private readonly IMongoDatabase _database;
        private readonly ILogger _logger;

        public AziendaRepository(IConfiguration configuration, ILogger<AziendaRepository> logger)
        {
            this._logger = logger;

            string? connessioneLocale = configuration.GetValue<string>("MongoDbSettings:Locale");
            string? databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

            MongoClient client = new MongoClient(connessioneLocale);
            this._database = client.GetDatabase(databaseName);
        }

        public bool Delete(Impiegato item)
        {
            throw new NotImplementedException();
        }

        public Impiegato Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Impiegato> GetAll()
        {
            IMongoCollection<Impiegato> impiegati = this._database.GetCollection<Impiegato>("Impiegatos");
            //List<Impiegato> elenco = impiegati.AsQueryable().ToList();
            return impiegati.Find(p => true).ToList();
        }

        public bool Insert(Impiegato item)
        {
            IMongoCollection<Impiegato> impiegati =  this._database.GetCollection<Impiegato>("Impiegatos");
            try
            {
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
            throw new NotImplementedException();
        }
    }
}
