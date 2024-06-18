using ManuelAguilar.API.ExceptionHandler;

namespace ManuelAguilar.API.Features.Posts.Exceptions;

public class NoAuthorExistsException : NotFoundException
{
    public NoAuthorExistsException(int authorId) 
        : base($"Author with id: {authorId} doesn't exist.") { }
}
