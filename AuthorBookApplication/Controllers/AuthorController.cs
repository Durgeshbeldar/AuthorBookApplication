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
        public AuthorController(IAuthorService service)
        {
            _authorService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDtos = _authorService.GetAuthors();
            if(authorDtos == null)
                return NotFound("Authors Not Found, Please Add Authors.");
            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetAuthor(id);
            if (author == null)
                return NotFound("Author Not Found");
            return Ok(author);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var authorDto = _authorService.FindAuthorByName(name);
            if (authorDto == null)
                return NotFound("Author Not Found");
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
            if (authorDto == null)
                return NotFound("Author Not Found to Update");
            return Ok(authorDto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_authorService.DeleteAuthor(id))
                return Ok("Author Deleted Successfully");
            return NotFound("Author Not Found");
        }  
    }
}
