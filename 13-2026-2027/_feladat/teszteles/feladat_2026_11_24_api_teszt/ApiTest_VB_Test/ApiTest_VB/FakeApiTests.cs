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
}