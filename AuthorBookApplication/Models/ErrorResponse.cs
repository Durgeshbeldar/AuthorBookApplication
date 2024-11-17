using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AuthorBookApplication.Models
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
