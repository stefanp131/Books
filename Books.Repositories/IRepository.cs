using System.Linq;

namespace Books.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void AttachEntity(T entity);
        void AddEntity(T entity);
        T GetEntityById(int id);
        void DeleteById(int id);
        void Save();
        void Dispose();
    }
}
