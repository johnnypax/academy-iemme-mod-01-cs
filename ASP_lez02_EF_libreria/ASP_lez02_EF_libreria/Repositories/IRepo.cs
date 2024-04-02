namespace ASP_lez02_EF_libreria.Repositories
{
    public interface IRepo<T>
    {
        T? GetById(int id);
        List<T> GetAll();
        bool insert(T t);
        bool update(T t);
        bool delete(int id);

    }
}
