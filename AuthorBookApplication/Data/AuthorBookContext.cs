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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many Relationship: Author to Books

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-One Relationship: Author to AuthorDetails

            modelBuilder.Entity<AuthorDetails>()
                .HasOne(ad => ad.Author)
                .WithOne(a => a.AuthorDetails)
                .HasForeignKey<AuthorDetails>(ad => ad.AuthorId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
