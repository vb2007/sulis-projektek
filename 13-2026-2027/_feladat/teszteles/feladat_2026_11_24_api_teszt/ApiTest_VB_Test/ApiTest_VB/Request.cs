using RestSharp;


public class Request
{

    var baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";

    public RestResponse GetFakeApiRequest()
    {
        RestClient client = new RestClient(baseUrl);
        RestRequest restRequest = new RestRequest(baseUrl, Method.Get);
        RestResponse restResponse = client.Execute(restRequest);

        return restResponse;
    }

}