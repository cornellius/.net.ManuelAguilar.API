using MediatR;
using ManuelAguilar.API.Domain;
using ManuelAguilar.API.Features.Posts.Exceptions;
using ManuelAguilar.API.RepositoryManager;

namespace ManuelAguilar.API.Features.Posts.Requests.AddPost;

public class AddPostHandler : IRequestHandler<AddPostCommand, AddPostResult>
{
    private readonly IRepositoryManager _repositoryManager;

    public AddPostHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<AddPostResult> Handle(AddPostCommand request, CancellationToken cancellationToken)
    {
        var author = await _repositoryManager.Author.GetAuthorByIdAsync(request.AuthorId);

        if (author is null)
            throw new NoAuthorExistsException(request.AuthorId);

        var post = new Post()
        {
            AuthorId = request.AuthorId,
            Title = request.Title,
            Description = request.Description,
            Content = request.Content
        };

        _repositoryManager.Post.AddPostToAuthor(request.AuthorId, post);

        await _repositoryManager.SaveAsync();

        AddPostResult addPostResult = new AddPostResult(
                Id: post.Id,
                AuthorId: post.AuthorId,
                Title: post.Title,
                Description: post.Description,
                Content: post.Content
            );

        return addPostResult;
    }
}
