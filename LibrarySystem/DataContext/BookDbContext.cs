

using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DataContext
{
    public class BookDbContext :DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Subcategories> subcategories { get; set; }
       
    }
}
