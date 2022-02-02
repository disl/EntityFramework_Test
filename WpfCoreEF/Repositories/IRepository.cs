using System.Collections.Generic;

namespace WpfCoreEF.Repositories
{
    public interface IRepository<T>
    {
        void Add(T Item);
        T Get(int id);
        List<T> GetAll();
        void Delete(int id);
        void Update(T Item);
    }
}
