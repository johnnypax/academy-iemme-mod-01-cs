using ASP_WEB_lez05_Preferiti.Models;
using ASP_WEB_lez05_Preferiti.Repositories;

namespace ASP_WEB_lez05_Preferiti.Services
{
    public class FilmService
    {
        private readonly FilmRepository _repo;

        public FilmService(FilmRepository repository)
        {
            _repo = repository;
        }

        public IEnumerable<Film> RestituisciTuttiFilm()
        {
            return _repo.GetAll();
        }
    }
}
