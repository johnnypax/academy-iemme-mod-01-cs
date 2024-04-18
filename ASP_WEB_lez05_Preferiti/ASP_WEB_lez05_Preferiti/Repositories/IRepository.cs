using ASP_WEB_lez05_Preferiti.Models;

namespace ASP_WEB_lez05_Preferiti.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<Film> GetAll();

        //TODO: Altri metodi...
    }
}
