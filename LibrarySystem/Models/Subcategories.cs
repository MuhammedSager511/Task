namespace LibrarySystem.Models
{
    public class Subcategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}
