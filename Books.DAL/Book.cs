using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string AuthorName { get; set; }
        [Range(0,100)]
        public decimal Price { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public virtual ICollection<Person> ReadedBy { get; set; }

        public Book()
        {
            ReadedBy = new HashSet<Person>();
        }
    }
}
