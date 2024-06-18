using ManuelAguilar.API.Data;
using ManuelAguilar.API.Features.Authors.Repository;
using ManuelAguilar.API.Features.Posts.Repository;

namespace ManuelAguilar.API.RepositoryManager;

public class RepositoryManager : IRepositoryManager
{
    private readonly ApiDbContext _context;
    private readonly Lazy<IAuthorRepository> _authorRepository;
    private readonly Lazy<IPostRepository> _postRepository;

    public RepositoryManager(ApiDbContext context)
    {
        _context = context;
        _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
        _postRepository = new Lazy<IPostRepository>(() => new PostRepository(_context));
    }

    public IAuthorRepository Author => _authorRepository.Value;
    public IPostRepository Post => _postRepository.Value;

    public Task SaveAsync() => _context.SaveChangesAsync();
}
