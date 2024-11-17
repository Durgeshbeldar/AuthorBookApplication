namespace AuthorBookApplication.Exceptions
{
    public class AuthorsNotFoundException : Exception
    {
        public AuthorsNotFoundException(string message):base(message) { }
    }
}
