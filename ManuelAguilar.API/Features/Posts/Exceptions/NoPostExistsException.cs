using ManuelAguilar.API.ExceptionHandler;

namespace ManuelAguilar.API.Features.Posts.Exceptions;

public class NoPostExistsException : NotFoundException
{
    public NoPostExistsException(int postId) 
        : base($"Post with id: {postId} doesn't exist")
    {
    }
}
