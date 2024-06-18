namespace ManuelAguilar.API.Features.Posts.Requests.AddPost;

public record AddPostResult(int Id, int AuthorId, string Title, string Description, string Content);