using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_lez05_task_eventi.DAL
{
    internal interface IDal<T>
    {
        List<T> GetAll();
        bool Insert(T t);

        //TODO: altri metodi
    }
}
