using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;

namespace AuthorBookApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.Add(author);
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

        public Author GetAuthor(int id)
        {
            return _authorRepository.GetById(id);
        }

        public List<Author> GetAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author UpdateAuthor(Author author)
        {
             return _authorRepository.Update(author);
        }
    }
}
