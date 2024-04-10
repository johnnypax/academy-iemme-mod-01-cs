using EF_CF_lez01_Migrations_Intro.Models;

namespace EF_CF_lez01_Migrations_Intro.Repos
{
    public class ContattoRepo : IRepo<Contatto>
    {
        private readonly ContattoContext _context;

        public ContattoRepo(ContattoContext context)
        {
            _context = context;
        }

        public bool Create(Contatto t)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Contatto t)
        {
            throw new NotImplementedException();
        }

        public Contatto? Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contatto> GetAll()
        {
            return _context.Contattos.ToList();
        }

        public bool Update(Contatto t)
        {
            throw new NotImplementedException();
        }
    }
}
