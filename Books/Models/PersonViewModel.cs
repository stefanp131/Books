using System.Collections.Generic;
using System.Web.Mvc;

namespace Books.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleViewModel Role { get; set; }
        public virtual ICollection<BookViewModel> RoleShelf { get; set; }

    }
}