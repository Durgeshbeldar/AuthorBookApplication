using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;

namespace AuthorBookApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
        }

        public bool DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                _bookRepository.Delete(book);
                return true;
            }
            return false;
        }

        public Book GetBook(int id)
        {
            return _bookRepository.GetById(id);
        }

        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book UpdateBook(Book book)
        {
            return _bookRepository.Update(book);
        }
    }
}
