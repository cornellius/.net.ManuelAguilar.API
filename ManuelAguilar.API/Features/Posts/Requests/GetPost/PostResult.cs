using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Features.Posts.Requests.GetPost;

public record PostResult(int Id, int AuthorId, string Title, string Description, string Content, Author Author);
