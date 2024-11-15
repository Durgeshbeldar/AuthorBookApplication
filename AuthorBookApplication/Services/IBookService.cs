using AuthorBookApplication.DTOs;
using AuthorBookApplication.Models;

namespace AuthorBookApplication.Services
{
    public interface IBookService
    {
        public List<BookDto> GetBooks();
        public BookDto GetBook(int id);
        public int AddBook(BookDto bookDto);
        public bool DeleteBook(int id);
        public BookDto UpdateBook(BookDto bookDto);

        public List<BookDto> FindBookByAuthorId(int authorId);
        public AuthorDto FindAuthorByBookId(int bookId);
    }
}
