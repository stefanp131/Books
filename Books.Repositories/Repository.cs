using Books.Entities;
using System.Linq;

namespace Books.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private BooksDB booksDb { get; set; }
        public Repository()
        {            
            booksDb = new BooksDB();
        }

        public IQueryable<T> GetAll()
        {
            return booksDb.Set<T>();
        }

        public void AttachEntity(T entity)
        {
            booksDb.Set<T>().Attach(entity);
        }

        public void AddEntity(T entity)
        {
            booksDb.Set<T>().Attach(entity);
            booksDb.Set<T>().Add(entity);
            booksDb.SaveChanges();
        }

        public T GetEntityById(int id)
        {
            return booksDb.Set<T>().Find(id);
        }

        public void DeleteById(int id)
        {
            var entity = booksDb.Set<T>().Find(id);
            booksDb.Set<T>().Attach(entity);
            booksDb.Set<T>().Remove(entity);
            booksDb.SaveChanges();
        }

        public void Save()
        {
            booksDb.SaveChanges();
        }

        public void Dispose()
        {
            booksDb.Dispose();
        }
    }
}
