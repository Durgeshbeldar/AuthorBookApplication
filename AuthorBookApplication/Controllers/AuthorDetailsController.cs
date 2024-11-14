using AuthorBookApplication.Models;
using AuthorBookApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthorBookApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _service;

        public AuthorDetailsController(IAuthorDetailsService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var authorDetails = _service.GetAuthorDetails();
            return Ok(authorDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var authorDetail = _service.GetAuthorDetails(id);
            if (authorDetail == null)
                return NotFound("Author Detail Not Found");
            return Ok(authorDetail);
        }

        [HttpPost]
        public IActionResult Post(AuthorDetails authorDetail)
        {
            _service.AddAuthorDetails(authorDetail);
            return Ok("Author Detail Added Successfully");
        }

        [HttpPut]
        public IActionResult Put(AuthorDetails updatedAuthorDetail)
        {
            var authorDetails = _service.UpdateAuthorDetails(updatedAuthorDetail);
            if(authorDetails == null)
            return NotFound("Author Detail Not Found");
            return Ok(authorDetails);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.DeleteAuthorDetails(id))
                return Ok("Author Detail Deleted Successfully");
            return NotFound("Author Detail Not Found");
        }
    }
}
