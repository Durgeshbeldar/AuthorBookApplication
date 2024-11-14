using Microsoft.EntityFrameworkCore;
using AuthorBookApplication.Data;
using AuthorBookApplication.Models;

namespace AuthorBookApplication.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AuthorBookContext _context;

        public AuthorRepository(AuthorBookContext context)
        {
            _context = context;
        }

        // Add a new author
        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        // Delete an existing author
        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        // Get a single author by id
        public Author GetAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            return author;
        }

        // Get list of all authors
        public List<Author> GetAuthors()
        {
            var authors = _context.Authors.ToList();
            return authors;
        }

        // Update an existing author
        public bool UpdateAuthor(Author author)
        {
            var existAuthor = _context.Authors.AsNoTracking().FirstOrDefault(a => a.Id == author.Id);
            if (existAuthor == null)
                return false;

            _context.Authors.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
