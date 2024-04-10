using EF_CF_lez01_Migrations_Intro.Models;
using EF_CF_lez01_Migrations_Intro.Repos;

namespace EF_CF_lez01_Migrations_Intro.Services
{
    public class ContattoService
    {
        private readonly ContattoRepo _repository;

        public ContattoService(ContattoRepo repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contatto> RestituisciTuttiContatti()
        {
            return _repository.GetAll().OrderBy(e => e.Cognome);
        }


    }
}
