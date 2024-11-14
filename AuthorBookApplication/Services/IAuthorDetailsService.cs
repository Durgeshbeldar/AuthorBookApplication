using AuthorBookApplication.Models;

namespace AuthorBookApplication.Services
{
    public interface IAuthorDetailsService
    {
        public List<AuthorDetails> GetAuthorDetails();
        public AuthorDetails GetAuthorDetails(int id);
        public void AddAuthorDetails(AuthorDetails authorDetails);
        public bool DeleteAuthorDetails(int id);
        public AuthorDetails UpdateAuthorDetails(AuthorDetails authorDetails);
    }
}
