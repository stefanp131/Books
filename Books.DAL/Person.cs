using System.Collections.Generic;

namespace Books.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public List<Book> RoleShelf { get; set; }
    }
}
