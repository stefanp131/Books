using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Entities
{
    public class Person
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string BookName { get; set; }

        public Role Role { get; set; }
        public virtual ICollection<Book> RoleShelf { get; set; }

        public Person()
        {
            RoleShelf = new HashSet<Book>();
        }
    }
}
