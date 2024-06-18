using ManuelAguilar.API.Features.Posts.Exceptions;
using MediatR;
using ManuelAguilar.API.RepositoryManager;

namespace ManuelAguilar.API.Features.Posts.Requests.GetPost
{
    public class GetPostHandler : IRequestHandler<GetPostQuery, IEnumerable<PostResult>>
    {
            private readonly IRepositoryManager _repositoryManager;

            public GetPostHandler(IRepositoryManager repositoryManager)
            {
                _repositoryManager = repositoryManager;
            }

            public async Task<IEnumerable<PostResult>> Handle(GetPostQuery request, CancellationToken cancellationToken)
            {
                var post = await _repositoryManager.Post.GetPostAsync(request.PostId, request.WithAuthor);
                
                if (post is null)
                    throw new NoPostExistsException(request.PostId);

                List<PostResult> results =
                [
                    new PostResult(
                        Id: post.Id,
                        AuthorId: post.AuthorId,
                        Title: post.Title,
                        Description: post.Description,
                        Content: post.Content,
                        Author: post.Author)
                ];

                return results;
            }
        }
}