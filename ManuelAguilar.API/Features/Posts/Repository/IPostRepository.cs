using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Features.Posts.Repository
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>?> GetAllPostsAsync();
        Task<Post?> GetPostAsync(int postId, string withAuthor);
        void AddPostToAuthor(int authorId, Post post);
    }
}
