namespace ASP_lez03_EF_Manuale_Ferramenta.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti();
    }
}
