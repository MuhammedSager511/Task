using System.ComponentModel.DataAnnotations.Schema;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int categoryId { get; set; }
        
        public Category Category { get; set; }
        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
