using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Models
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
                : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}