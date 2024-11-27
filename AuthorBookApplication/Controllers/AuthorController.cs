using AuthorBookApplication.DTOs;
using AuthorBookApplication.Models;
using AuthorBookApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthorBookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public AuthorController(IAuthorService service, IBookService bookService)
        {
            _authorService = service;
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDtos = _authorService.GetAuthors();
            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetAuthor(id);
            return Ok(author);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var authorDto = _authorService.FindAuthorByName(name);
            return Ok(authorDto);
        }

        // For Understanding Purposes I have Written Route Path in a Descriptive Way

        [HttpGet("book/{bookId}")]
        public IActionResult FindAuthorByBookId(int bookId)
        {
            var authorDto = _bookService.FindAuthorByBookId(bookId);
            return Ok(authorDto);
        }

        [HttpPost]
        public IActionResult Add(AuthorDto authorDto)
        {
            int id = _authorService.AddAuthor(authorDto);
            return Ok($"Author Added Successfully and Author Id : {id}");
        }

        [HttpPut]
        public IActionResult Update(AuthorDto updatedAuthorDto)
        {
            var authorDto = _authorService.UpdateAuthor(updatedAuthorDto);
            return Ok(authorDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok("Author Deleted Successfully");
        }  
    }
}
