using AuthorBookApplication.DTOs;
using AuthorBookApplication.Models;
using AuthorBookApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthorBookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService service)
        {
            _bookService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookDtos = _bookService.GetBooks();
            if (bookDtos == null)
                return NotFound("Books Not Found. Please Add The Books");
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBook(id);
            if (book == null)
                return NotFound($"Book Not Found with Id : {id}");
            return Ok(book);
        }

        // For Understanding Purposes I have Written Route Path in a Descriptive Way

        [HttpGet("GetBooksByAuthorId/{authorId}")]
        public IActionResult FindBooksByAuthorId(int authorId)
        {
            var bookDtos = _bookService.FindBookByAuthorId(authorId);
            if (bookDtos == null)
                return NotFound($"Book Or Books Not Found With Given AuthorId : {authorId}");
            return Ok(bookDtos);
        }

        // For Understanding Purposes I have Written Route Path in a Descriptive Way

        [HttpGet("GetAuthorByBookId/{bookId}")]
        public IActionResult FindAuthorByBookId(int bookId)
        {
            var authorDto = _bookService.FindAuthorByBookId(bookId);
            if (authorDto == null)
                return NotFound("Author Not Found");
            return Ok(authorDto);
        }

        [HttpPost]
        public IActionResult Add(BookDto bookDto)
        {
            int id = _bookService.AddBook(bookDto);
            return Ok($"Book Added Successfully and Id is : {id}");
        }

        [HttpPut]
        public IActionResult Update(BookDto updatedBookDto)
        {
            var bookDto = _bookService.UpdateBook(updatedBookDto);
            return Ok(bookDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_bookService.DeleteBook(id))
                return Ok("Book Deleted Successfully");
            return NotFound($"Book Not Found with the bookId : {id}");
        }
    }
}
