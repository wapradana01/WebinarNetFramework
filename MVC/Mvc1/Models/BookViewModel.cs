namespace Mvc1.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookTitle { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
