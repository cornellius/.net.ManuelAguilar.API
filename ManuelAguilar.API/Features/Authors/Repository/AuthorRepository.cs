using Microsoft.EntityFrameworkCore;
using ManuelAguilar.API.Data;
using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Features.Authors.Repository;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApiDbContext _context;

    public AuthorRepository(ApiDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        return await _context.Authors
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int authorId)
    {
        return await _context.Authors
            .FirstOrDefaultAsync(x => x!.Id == authorId);
    }
}
