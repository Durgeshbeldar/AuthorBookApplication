using AuthorBookApplication.Models;

namespace AuthorBookApplication.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();
        public Book GetBook(int id);
        public void AddBook(Book book);
        public void DeleteBook(Book book);
        public bool UpdateBook(Book book);
    }
}
