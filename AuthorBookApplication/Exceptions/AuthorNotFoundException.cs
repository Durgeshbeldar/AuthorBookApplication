namespace AuthorBookApplication.Exceptions
{
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException(string message) : base(message) { }
    }
}
