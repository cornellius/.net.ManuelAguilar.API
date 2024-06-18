using MediatR;
using Microsoft.AspNetCore.Mvc;
using ManuelAguilar.API.Features.Authors.Requests.GetAllAuthors;

namespace ManuelAguilar.API.Features.Authors;

[Route("authors")]
[ApiController]
public class AuthorsController(ISender sender) : ControllerBase
{
    [HttpGet, ActionName("GetAuthors")]
    public async Task<ActionResult<IEnumerable<AuthorResult>>> GetAuthorsAsync()
    {
        var result = await sender.Send(new GetAuthorsQuery());

        if (result is null)
            return NotFound();

        return Ok(result);
    }
}
