namespace AuthorBookApplication.Exceptions
{
    public class BooksNotFoundException : Exception
    {
        public BooksNotFoundException(string message) : base(message) { }
    }
}
