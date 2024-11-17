using AuthorBookApplication.DTOs;
using AuthorBookApplication.Exceptions;
using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        public bool DeleteBook(int bookId)
        {
            var book = _bookRepository.GetById(bookId);
            if (book != null)
            {
                _bookRepository.Delete(book);
                return true;
            }
            throw new BookNotFoundException
                ($"The Book With ID {bookId} Could Not Be Found. Please Check The ID And Try Again.");
        }

        public BookDto GetBook(int bookId)
        {
            var book = _bookRepository.GetAll().Include(b => b.Author).Where(b => b.Id == bookId).FirstOrDefault(); 
            if(book == null)
                throw new BookNotFoundException
             ($"The Book With ID {bookId} Could Not Be Found. Please Check The ID And Try Again.");
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public List<BookDto> GetBooks()
        {
            var books =  _bookRepository.GetAll().Include(b=> b.Author).ToList();
            if(books.Count == 0)
                throw new BooksNotFoundException
             ($"Books Not Found. Please Try Again.");
            List<BookDto> bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public List<BookDto> FindBookByAuthorId(int authorId)
        {
            var books = _bookRepository.GetAll().Include(b => b.Author).Where(b=> b.AuthorId == authorId).ToList();
            if(books.Count == 0)
                throw new BooksNotFoundException
             ($"Book/Books Not Found With Author Id {authorId}. Please Try Again.");
            List<BookDto> bookDtos = _mapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public AuthorDto FindAuthorByBookId(int bookId)
        {
            var book = _bookRepository.GetAll().Include(b => b.Author).Where(b=> b.Id == bookId).FirstOrDefault();
            if(book == null)
                throw new BookNotFoundException
                ($"The Book With ID {bookId} Could Not Be Found. Please Check The ID And Try Again.");
            var author = book.Author;
            if(author == null)
                throw new AuthorNotFoundException("Author Not Found");

            // To Set TotalBooks Count Written By Author, I Am retriving all the books by author Id 

            author.Books = _bookRepository.GetAll().Where(b=> b.AuthorId == author.Id).ToList();
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }
        public BookDto UpdateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            var existingBook = _bookRepository.GetAll().Include(b=> b.Author).AsNoTracking().FirstOrDefault(b => b.Id == book.Id);
            if(existingBook == null)
                throw new BookNotFoundException
            ($"The Book With ID {book.Id} Could Not Be Found. Please Check The ID And Try Again.");
            _bookRepository.Update(book);
            return bookDto;
        }
    }
}
