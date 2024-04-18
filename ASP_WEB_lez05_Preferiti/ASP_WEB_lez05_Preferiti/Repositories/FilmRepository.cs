using ASP_WEB_lez05_Preferiti.Models;

namespace ASP_WEB_lez05_Preferiti.Repositories
{
    public class FilmRepository : IRepository<Film>
    {
        public IEnumerable<Film> GetAll()
        {
            List<Film> films = new List<Film>();
            films.Add(new Film() { Titolo = "Memento", Regista = "Nolan", Codice = "MM123", Categoria = "Thriller" });
            films.Add(new Film() { Titolo = "Sharknado", Regista = "Ferrante", Codice = "SH124", Categoria = "Trash" });
            films.Add(new Film() { Titolo = "The human centipede", Regista = "Prova", Codice = "SH123", Categoria = "Trash" });
            films.Add(new Film() { Titolo = "Il vecchio conio", Regista = "Maccio", Codice = "VC123", Categoria = "Comico" });

            return films;
        }
    }
}
