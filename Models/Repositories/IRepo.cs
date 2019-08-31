using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreApp.Models.Repositories
{
    public interface IRepo<T>
    {
        void Add(T t);
        void Delete(int id);
        void Update(T t);
        T Find(int id);
        List<T> GetAll();
        int Commit();
    }
}
