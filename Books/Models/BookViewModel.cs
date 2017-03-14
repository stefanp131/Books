﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [Range(0, 100)]
        public decimal Price { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public virtual ICollection<PersonViewModel> ReadedBy { get; set; }
    }
}