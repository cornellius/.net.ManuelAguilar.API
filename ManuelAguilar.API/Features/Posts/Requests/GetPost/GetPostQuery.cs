using MediatR;

namespace ManuelAguilar.API.Features.Posts.Requests.GetPost;

public record GetPostQuery(int PostId, string WithAuthor) : IRequest<IEnumerable<PostResult>>;

public record GetPostWithAuthorQuery(int PostId, string WithAuthor) : IRequest<IEnumerable<PostWithAuthorResult>>;