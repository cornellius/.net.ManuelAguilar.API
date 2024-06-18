using MediatR;
using ManuelAguilar.API.RepositoryManager;

namespace ManuelAguilar.API.Features.Authors.Requests.GetAllAuthors;

public class GetAllAuthorsHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorResult>>
{
    private readonly IRepositoryManager _repositoryManager;

    public GetAllAuthorsHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task<IEnumerable<AuthorResult>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _repositoryManager.Author.GetAllAuthorsAsync();
        
        List <AuthorResult> results = new List<AuthorResult>();
        
        foreach(var author in authors)
        {
            results.Add(
                new AuthorResult(
                    Id: author.Id,
                    Name: author.Name,
                    Surname: author.Surname
                    ));
        }

        return results;
    }
}
