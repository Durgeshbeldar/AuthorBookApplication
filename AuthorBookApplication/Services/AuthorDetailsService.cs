using AuthorBookApplication.Models;
using AuthorBookApplication.Repositories;

namespace AuthorBookApplication.Services
{
    public class AuthorDetailsService : IAuthorDetailsService
    {
        private readonly IRepository<AuthorDetails> _authorDetailsRepository;

        public AuthorDetailsService(IRepository<AuthorDetails> authorDetailsRepository)
        {
            _authorDetailsRepository = authorDetailsRepository;
        }

        public void AddAuthorDetails(AuthorDetails authorDetails)
        {
            _authorDetailsRepository.Add(authorDetails);
        }

        public bool DeleteAuthorDetails(int id)
        {
            var authorDetails = _authorDetailsRepository.GetById(id);
            if (authorDetails != null)
            {
                _authorDetailsRepository.Delete(authorDetails);
                return true;
            }
            return false;
        }

        public AuthorDetails GetAuthorDetails(int id)
        {
            return _authorDetailsRepository.GetById(id);
        }

        public List<AuthorDetails> GetAuthorDetails()
        {
            return _authorDetailsRepository.GetAll();
        }

        public AuthorDetails UpdateAuthorDetails(AuthorDetails authorDetails)
        {
            return _authorDetailsRepository.Update(authorDetails);
        }
    }
}
