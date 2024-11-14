using AuthorBookApplication.Models;

namespace AuthorBookApplication.Services
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
        public void AddBook(Book book);
        public bool DeleteBook(int id);
        public Book UpdateBook(Book book);
    }
}
