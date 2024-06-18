using MediatR;

namespace ManuelAguilar.API.Features.Posts.Requests.AddPost;

public record AddPostCommand(int AuthorId, string Title, string Description, string Content) : IRequest<AddPostResult>;