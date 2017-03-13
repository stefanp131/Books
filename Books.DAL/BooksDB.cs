using System.Data.Entity;

namespace Books.Entities
{
    public class BooksDB : DbContext
    {
        public BooksDB() : base("BooksDB")
        {

        }

        public DbSet <Book> Books { get; set; }
        public DbSet <Person> People { get; set; }        
    }
}
