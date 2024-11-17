using AuthorBookApplication.DTOs;
using AuthorBookApplication.Exceptions;
using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public int AddAuthor(AuthorDto authorDto)
        {
            Author author = _mapper.Map<Author>(authorDto);
            _authorRepository.Add(author);
            return author.Id;
        }

        public bool DeleteAuthor(int id)
        {
            var author = _authorRepository.GetById(id);
            if (author != null)
            {
                _authorRepository.Delete(author);
                return true;
            }
            throw new AuthorNotFoundException("Author Not Found to Delete");
        }

        public AuthorDto GetAuthor(int id)
        {
            var author =  _authorRepository.GetAll().Include
                (a => a.AuthorDetails).Include(a => a.Books).FirstOrDefault(a=> a.Id == id);
            if (author == null)
                throw new AuthorNotFoundException("Author Not Found");
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public List<AuthorDto> GetAuthors()
        {
            var authors = _authorRepository.GetAll().Include(a=> a.AuthorDetails).Include(a=> a.Books).ToList();
            if(authors == null)
                throw new AuthorNotFoundException("Authors Not Found");
            List<AuthorDto> authorDtos = _mapper.Map<List<AuthorDto>>(authors);
            return authorDtos;
        }

        public AuthorDto UpdateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            var existingAuthor = _authorRepository.GetAll().Include
                (a=> a.Books).Include(a=> a.AuthorDetails).AsNoTracking().FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                _authorRepository.Update(author);
                return authorDto;
            }
            throw new AuthorNotFoundException("Author Not Found");
        }

        public AuthorDto FindAuthorByName(string name)
        {
            var author = _authorRepository.GetAll().Include
                (a => a.AuthorDetails).Include(a => a.Books).FirstOrDefault(a => a.Name == name);
            if (author == null)
                throw new AuthorNotFoundException("Author Not Found");
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }
    }
}
