using MediatR;
using Microsoft.AspNetCore.Mvc;
using ManuelAguilar.API.Features.Posts.Requests.AddPost;
using ManuelAguilar.API.Features.Posts.Requests.GetPost;
using Microsoft.Extensions.Primitives;

namespace ManuelAguilar.API.Features.Posts;

[Route("post")]
[ApiController]
public class PostsController(ISender sender) : ControllerBase
{
    [HttpPost(Name="AddPost")]
    public async Task<ActionResult> AddPost(AddPostCommand command)
    {
        var result = await sender.Send(command);

        return CreatedAtAction("GetPost", new { id = result.Id }, result);
    }
    
    [HttpGet("{id:int}", Name="GetPost")]
    public async Task<ActionResult<IEnumerable<PostResult>>> GetPostAsync(int id)
    {
        // Header key for withAuthor
        const string headerKeyName = "WithAuthor"; 
        var withAuthor = string.Empty;
        
        if (Request.Headers.TryGetValue(headerKeyName, out var headerValues))
        {
            withAuthor = headerValues.FirstOrDefault();
        }  
        
        var query = new GetPostQuery(id, withAuthor);
        var result = await sender.Send(query);

        return Ok(result);
    }
}
