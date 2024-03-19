using DB_lez02_dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_lez02_dal.DAL
{
    interface IDal<T>
    {
        bool insert(T t);
        List<T> findAll();
        T findById(int id);
        bool delete(int id);
        bool update(T t);

    }
}
