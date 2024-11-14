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
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var authors = _service.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _service.GetAuthor(id);
            if (author == null)
                return NotFound("Author Not Found");
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post(Author author)
        {
            _service.AddAuthor(author);
            return Ok("Author Added Successfully");
        }

        [HttpPut]
        public IActionResult Put(Author updatedAuthor)
        {
            var Author = _service.UpdateAuthor(updatedAuthor);
            if (Author == null)
                return NotFound("Author Not Found");
            return Ok(Author);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteAuthor(id))
                return Ok("Author Deleted Successfully");
            return NotFound("Author Not Found");
        }
    }
}
