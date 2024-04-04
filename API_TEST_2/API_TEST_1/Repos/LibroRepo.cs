using API_TEST_1.Models;

namespace API_TEST_1.Repos
{
    public class LibroRepo : IRepository<Libro>
    {
        private readonly LibroContext _context;

        public LibroRepo(LibroContext context)
        {
            _context = context;
        }

        public IEnumerable<Libro> GetAll()
        {
            return _context.Libri.ToList();
        }

        public Libro? Get(int id)
        {
            return _context.Libri.Find(id);
        }

        public void Create(Libro student)
        {
            _context.Libri.Add(student);
            _context.SaveChanges();
        }

        public void Update(Libro student)
        {
            _context.Libri.Update(student);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Libri.Find(id);
            if (student != null)
            {
                _context.Libri.Remove(student);
                _context.SaveChanges();
            }
        }
    }

}
