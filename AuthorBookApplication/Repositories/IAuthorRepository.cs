using AuthorBookApplication.Models;

namespace AuthorBookApplication.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthor(int id);
        public void AddAuthor(Author author);
        public void DeleteAuthor(Author author);
        public bool UpdateAuthor(Author author);
    }
}
