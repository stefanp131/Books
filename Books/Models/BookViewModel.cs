namespace Books.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}