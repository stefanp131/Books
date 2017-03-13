using Books.Entities;
using System.Linq;

namespace Books.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAllBooks();
        void Add(Book book);
        Book GetBookById(int id);
        void Save();
        void DeleteById(int id);
    }
}
