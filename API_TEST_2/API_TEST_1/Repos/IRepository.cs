using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_TEST_1.Repos
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
