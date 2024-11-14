using AuthorBookApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApplication.Data
{
    public class AuthorBookContext : DbContext
    {
        
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetails { get; set; }

        
        public AuthorBookContext(DbContextOptions<AuthorBookContext> options) : base(options)
        {
        }

    }
}
