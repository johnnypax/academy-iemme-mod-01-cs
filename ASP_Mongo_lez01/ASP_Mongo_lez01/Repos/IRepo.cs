namespace ASP_Mongo_lez01.Repos
{
    public interface IRepo<T>
    {
        T Get(int id);
        List<T> GetAll();
        bool Insert (T item);
        bool Update (T item);
        bool Delete (T item);
    }
}
