using Microsoft.EntityFrameworkCore;
using AuthorBookApplication.Data;
using AuthorBookApplication.Models;

namespace AuthorBookApplication.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AuthorBookContext _context;

        public BookRepository(AuthorBookContext context)
        {
            _context = context;
        }

        // Add a new book
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        // Delete an existing book
        public void DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        // Get a single book by id
        public Book GetBook(int id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        // Get list of all books
        public List<Book> GetBooks()
        {
            var books = _context.Books.ToList();
            return books;
        }

        // Update an existing book
        public bool UpdateBook(Book book)
        {
            var existBook = _context.Books.AsNoTracking().FirstOrDefault(b => b.Id == book.Id);
            if (existBook == null)
                return false;

            _context.Books.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
