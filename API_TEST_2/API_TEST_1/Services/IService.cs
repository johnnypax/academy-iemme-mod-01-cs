using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_TEST_1.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T t);
        void Update(T t);
        void Delete(int id);
    }
}
