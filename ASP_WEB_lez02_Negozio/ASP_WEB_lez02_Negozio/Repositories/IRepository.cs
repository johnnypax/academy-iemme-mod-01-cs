namespace ASP_WEB_lez02_Negozio.Repositories
{
    public interface IRepository<T>
    {
        bool Insert(T t);
        T? GetById(int id);
        List<T> GetAll();
        bool Delete(int id);
        bool Update(T t);
    }
}
