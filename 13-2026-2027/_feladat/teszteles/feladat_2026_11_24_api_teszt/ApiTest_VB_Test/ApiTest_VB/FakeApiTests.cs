using System.Net;
using System.Text.Json;
using FluentAssertions;
using RestSharp;

public class FakeApiTests
{
    Request request = new Request();

    [Test]
    public void SearchBooks()
    {
        RestResponse restResponse = request.GetFakeApiRequest();
        restResponse.Should().NotBeNull();
        restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public void CreateABook()
    {
        RestResponse response = request.PostFakeApiRequest();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNull();
        var bodyContent = JsonSerializer.Deserialize<FakeApiEntities>(response.Content);
        bodyContent!.Id.Should().NotBeNull();
        bodyContent.Description.Should().NotBeNull();
        bodyContent.Title.Should().NotBeNull();
    }
}