using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JetBrains.Annotations;
using ManuelAguilar.API.Features.Posts;
using ManuelAguilar.API.Features.Posts.Repository;
using ManuelAguilar.API.Features.Posts.Requests.GetPost;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ManuelAguilar.API.Tests.Features.Posts;

[TestSubject(typeof(PostsController))]
public class PostsControllerTest
{
    private readonly Mock<ISender> _sender;

    public PostsControllerTest()
    {
        _sender = new Mock<ISender>();
    }

    [Fact]
    public async Task GetPost_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        const int id = 1;
        var withAuthor = string.Empty;
        var query = new GetPostQuery(id, withAuthor);
        
        List<PostResult> senderResult =
        [
            new PostResult(
                Id: 1,
                AuthorId: 2,
                Title: "Title #1",
                Description: "Description #1",
                Content: "Content # 1",
                Author: null)
        ];
        _sender.Setup(c => c.Send(query)).Returns(senderResult.AsEnumerable());
        var sut = new PostsController(_sender.Object);

        //Act
        var result = await _sender.Object.Send(query);

        //Assert
        // result.StatusCode.Should().Be(200);
    }
}