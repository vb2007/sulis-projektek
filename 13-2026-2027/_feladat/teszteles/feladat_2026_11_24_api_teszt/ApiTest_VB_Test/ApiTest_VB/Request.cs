using RestSharp;


public class Request
{

    string baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";

    public RestResponse GetFakeApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }

    public static FakeApiEntities BuildBodyRequest(int? id = null)
    {
        return new FakeApiEntities
        {
            Id = id ?? 100,
            Title = "Test Book",
            Description = "Mussum Ipsum, cacilds vidis litro abertis.  Quem num gosta di mim que vai caçá sua turmis!",
            Excerpt = "uem num gosta di mim que vai caçá sua turmis!",
            PageCount = 100,
            PublishDate = "2023-09-03T13:50:32.6884665+00:00"
        };
    }

    //------

    public RestResponse PostFakeApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        FakeApiEntities body = BuildBodyRequest();
        RestRequest restRequest = new RestRequest(baseUrl, Method.Post);
        restRequest.AddBody(body, ContentType.Json);

        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }

    public RestResponse PutFakeApiRequest(int id)
    {
        RestClient client = new RestClient(baseUrl);
        var body = BuildBodyRequest(id);
        RestRequest restRequest = new RestRequest($"{baseUrl}/{id}", Method.Put);
        restRequest.AddBody(body, ContentType.Json);

        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }
}