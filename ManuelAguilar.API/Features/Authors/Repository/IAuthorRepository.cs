using ManuelAguilar.API.Domain;

namespace ManuelAguilar.API.Features.Authors.Repository;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();
    Task<Author?> GetAuthorByIdAsync(int authorId);
}
