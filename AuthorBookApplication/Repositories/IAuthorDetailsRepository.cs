using AuthorBookApplication.Models;

namespace AuthorBookApplication.Repositories
{
    public interface IAuthorDetailsRepository
    {
        public List<AuthorDetails> GetAuthorDetails();
        public AuthorDetails GetAuthorDetail(int id);
        public void AddAuthorDetail(AuthorDetails authorDetail);
        public void DeleteAuthorDetail(AuthorDetails authorDetail);
        public bool UpdateAuthorDetail(AuthorDetails authorDetail);
    }
}
