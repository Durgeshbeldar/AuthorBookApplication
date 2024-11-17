using AuthorBookApplication.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AuthorBookApplication.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                              Exception exception,
                                              CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is AuthorNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Author Not Found Please Enter Valid Input";
            }
            else if(exception is AuthorsNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Authors Not Found";
            }
            else if (exception is AuthorsNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Authors Not Found";
            }
            else if (exception is BookNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Book Not Found. Please Check The Book ID And Try Again.";
            }
            else if (exception is BooksNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Books Not Found. Please Verify The Input And Try Again.";
            }
            else if (exception is AuthorDetailsNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Author Details Not Found. Ensure You Provide Correct Details.";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = exception.Message;
                response.Title = "Something Went Wrong, Try Again!";
            }

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}
