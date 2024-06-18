using MediatR;

namespace ManuelAguilar.API.Features.Authors.Requests.GetAllAuthors;

public record GetAuthorsQuery : IRequest<IEnumerable<AuthorResult>>;