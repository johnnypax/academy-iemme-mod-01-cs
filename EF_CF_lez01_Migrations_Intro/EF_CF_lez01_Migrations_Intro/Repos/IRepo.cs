using EF_CF_lez01_Migrations_Intro.Models;

namespace EF_CF_lez01_Migrations_Intro.Repos
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        bool Create(T t);
        bool Update(T t);
        bool Delete(T t);
    }
}
