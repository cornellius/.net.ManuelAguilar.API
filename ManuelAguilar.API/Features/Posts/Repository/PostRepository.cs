using Microsoft.EntityFrameworkCore;
using ManuelAguilar.API.Data;
using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Features.Posts.Repository
{
    public class PostRepository(ApiDbContext context) : IPostRepository
    {
        public void AddPostToAuthor(int authorId, Post post)
        {
            post.AuthorId = authorId;

            context.Posts.Add(post);
        }

        public async Task<IEnumerable<Post>?> GetAllPostsAsync()
        {
            return await context.Posts
                .ToListAsync();
        }

        public async Task<Post?> GetPostAsync(int postId, string withAuthor = "")
        {
            if (withAuthor != "")
            {
                return await context.Posts.Include(a => a.Author).FirstOrDefaultAsync(i => i.Id == postId);
            }
            else
            {
                return await context.Posts.FindAsync(postId);
            }    
        }
    }
}
