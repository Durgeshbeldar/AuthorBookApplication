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
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _service.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _service.GetBook(id);
            if (book == null)
                return NotFound("Book Not Found");
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _service.AddBook(book);
            return Ok("Book Added Successfully");
        }

        [HttpPut]
        public IActionResult Put(Book updatedBook)
        {
            var book = _service.UpdateBook(updatedBook);
            if(book == null)    
            return NotFound("Book Not Found");
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteBook(id))
                return Ok("Book Deleted Successfully");
            return NotFound("Book Not Found");
        }
    }
}
