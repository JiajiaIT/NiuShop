using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBase<T>
    {
        List<T> GetAll();

        T FindById(int id);

        void Add(T obj);

        void Update(int id, T obj);

        void Delete(int id);

    }
}
