using AuthorBookApplication.DTOs;
using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public int AddBook(BookDto bookDto)
        {
            Book book = _mapper.Map<Book>(bookDto);
            _bookRepository.Add(book);
            return book.Id;
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

        public BookDto GetBook(int id)
        {
            var book = _bookRepository.Get().Include(b => b.Author).Where(b => b.Id == id).FirstOrDefault();    
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public List<BookDto> GetBooks()
        {
            var books =  _bookRepository.Get().Include(b=> b.Author).ToList();
            List<BookDto> bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public List<BookDto> FindBookByAuthorId(int authorId)
        {
            var books = _bookRepository.Get().Include(b => b.Author).Where(b=> b.AuthorId == authorId).ToList();
            List<BookDto> bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public AuthorDto FindAuthorByBookId(int bookId)
        {
            var book = _bookRepository.Get().Include(b => b.Author).Where(b=> b.Id == bookId).FirstOrDefault();
            var author = book.Author;
            author.Books = _bookRepository.Get().Where(b=> b.AuthorId == author.Id).ToList();
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;

        }
        public BookDto UpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var existingBook = _bookRepository.Get().Include(b=> b.Author).AsNoTracking().FirstOrDefault(b => b.Id == book.Id);
            if(existingBook != null)
            {
                _bookRepository.Update(book);
                return bookDto;
            }
            return _mapper.Map<BookDto>(existingBook);
        }
    }
}
