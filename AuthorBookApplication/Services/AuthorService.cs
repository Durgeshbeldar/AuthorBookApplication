using AuthorBookApplication.DTOs;
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
            return false;
        }

        public AuthorDto GetAuthor(int id)
        {
            var author =  _authorRepository.Get().Include
                (a => a.AuthorDetails).Include(a => a.Books).FirstOrDefault(a=> a.Id == id);
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public List<AuthorDto> GetAuthors()
        {
            var authors = _authorRepository.Get().Include(a=> a.AuthorDetails).Include(a=> a.Books).ToList();
            List<AuthorDto> authorDtos = _mapper.Map<List<AuthorDto>>(authors);
            return authorDtos;
        }

        public AuthorDto UpdateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            var existingAuthor = _authorRepository.Get().Include
                (a=> a.Books).Include(a=> a.AuthorDetails).AsNoTracking().FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                _authorRepository.Update(author);
                return authorDto;
            }
            return _mapper.Map<AuthorDto>(existingAuthor);
        }

        public AuthorDto FindAuthorByName(string name)
        {
            var author = _authorRepository.Get().Include
                (a => a.AuthorDetails).Include(a => a.Books).FirstOrDefault(a => a.Name == name);
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }
    }
}
