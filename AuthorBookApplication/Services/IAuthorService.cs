using AuthorBookApplication.Models;

namespace AuthorBookApplication.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthor(int id);
        public void AddAuthor(Author author);
        public bool DeleteAuthor(int id);
        public Author UpdateAuthor(Author author);
    }
}
