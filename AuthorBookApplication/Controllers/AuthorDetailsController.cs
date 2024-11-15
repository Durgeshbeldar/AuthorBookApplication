﻿using AuthorBookApplication.DTOs;
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
        private readonly IAuthorDetailsService _authorDetailService;

        public AuthorDetailsController(IAuthorDetailsService service)
        {
            _authorDetailService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authorDetails = _authorDetailService.GetAuthorDetails();
            if (authorDetails == null)
                return NotFound("Author Details For Authors Not Found.");
            return Ok(authorDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var authorDetail = _authorDetailService.GetAuthorDetail(id);
            if (authorDetail == null)
                return NotFound("Author Detail Not Found");
            return Ok(authorDetail);
        }

        [HttpGet("GetAuthorDetailsByAuthorId/{authorId}")]
        public IActionResult GetAuhorDetailsByAuthorId(int authorId)
        {
            var authorDetail = _authorDetailService.FindAuthorDetailsByAuthorId(authorId);
            if (authorDetail == null)
                return NotFound("Author Detail Not Found");
            return Ok(authorDetail);
        }
        [HttpPost]
        public IActionResult Add(AuthorDetailsDto authorDetailDto)
        {
            _authorDetailService.AddAuthorDetails(authorDetailDto);
            return Ok("Author Detail Added Successfully");
        }

        [HttpPut]
        public IActionResult Update(AuthorDetailsDto updatedAuthorDetailDto)
        {
            var authorDetails = _authorDetailService.UpdateAuthorDetails(updatedAuthorDetailDto);
            return Ok(authorDetails);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_authorDetailService.DeleteAuthorDetails(id))
                return Ok("Author Detail Deleted Successfully");
            return NotFound("Author Detail Not Found");
        }
    }
}
