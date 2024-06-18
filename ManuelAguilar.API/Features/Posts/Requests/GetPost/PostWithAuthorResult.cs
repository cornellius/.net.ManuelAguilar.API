using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Features.Posts.Requests.GetPost;

public record PostWithAuthorResult(int Id, int AuthorId, string Title, string Description, string Content, string AuthorName, string AuthorSurname);

