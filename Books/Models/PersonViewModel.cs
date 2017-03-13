using System.Collections.Generic;

namespace Books.Models
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoleViewModel Role { get; set; }
        public List<BookViewModel> RoleShelf { get; set; }
    }
}