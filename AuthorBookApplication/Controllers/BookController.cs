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
            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }

        // For Understanding Purposes I have Written Route Path in a Descriptive Way

        [HttpGet("Author/{authorId}")]
        public IActionResult FindBooksByAuthorId(int authorId)
        {
            var bookDtos = _bookService.FindBookByAuthorId(authorId);
            return Ok(bookDtos);
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
              return Ok($"Book Deleted Successfully with Id : {id}");
        }
    }
}
