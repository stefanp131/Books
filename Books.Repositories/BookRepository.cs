using Books.Entities;
using System.Linq;
using System;

namespace Books.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BooksDB booksDb { get; set; }

        public BookRepository()
        {
            booksDb = new BooksDB();
        }

        public IQueryable<Book> GetAllBooks()
        {
            return booksDb.Books;
        }

        public void Add(Book book)
        {
            booksDb.Books.Add(book);
            booksDb.SaveChanges();
        }

        public Book GetBookById(int id)
        {
            return booksDb.Books.Find(id);
        }

        public void Save()
        {
            booksDb.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var book = booksDb.Books.Find(id);
            booksDb.Books.Remove(book);
            booksDb.SaveChanges();
        }
    }
}
