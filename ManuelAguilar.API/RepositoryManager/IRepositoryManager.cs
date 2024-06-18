using ManuelAguilar.API.Features.Authors.Repository;
using ManuelAguilar.API.Features.Posts.Repository;

namespace ManuelAguilar.API.RepositoryManager;

public interface IRepositoryManager
{
    IAuthorRepository Author { get; }
    IPostRepository Post { get; }
    Task SaveAsync();
}
