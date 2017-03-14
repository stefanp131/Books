using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string BookName { get; set; }
        public RoleViewModel Role { get; set; }
        public virtual ICollection<BookViewModel> RoleShelf { get; set; }

    }
}