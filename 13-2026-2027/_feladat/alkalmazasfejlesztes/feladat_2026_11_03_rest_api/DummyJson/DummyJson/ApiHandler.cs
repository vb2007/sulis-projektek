using System.Net.Http.Headers;
using System.Text.Json;

namespace DummyJson;

public class ApiHandler
{
    private readonly HttpClient _httpClient;

    public ApiHandler(string baseUrl)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public record ProductResponse(string title, string description, decimal price);
    public record CountResponse(int total);
    public record ProductListResponse(List<ProductResponse> products);

    //cancellation token példa, kikommentelve program.cs-ben is
    // public async Task<ProductResponse?> GetProductAsync(string path, CancellationToken cancellationToken)
    // {
    //     ProductResponse? productResponse = null;
    //     
    //     try
    //     {
    //         HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(path);
    //         if (httpResponseMessage.IsSuccessStatusCode)
    //         {
    //             string content = await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken);
    //             productResponse = JsonSerializer.Deserialize<ProductResponse>(content);
    //         }
    //     }
    //     catch (Exception ex) { }
    //     
    //     return productResponse;
    // }
    
    public async Task<ProductResponse?> GetProductAsync(string path)
    {
        ProductResponse? productResponse = null;
        
        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(path);
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            productResponse = JsonSerializer.Deserialize<ProductResponse>(content);
        }

        return productResponse;
    }

    public async Task<CountResponse?> GetCategoryCountAsync(string category)
    {
        CountResponse? countResponse = null;

        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"category/{category}?limit=1&select=id");
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            countResponse = JsonSerializer.Deserialize<CountResponse>(content);
        }

        return countResponse;
    }

    public async Task<ProductListResponse?> GetCategoryProductsAsync(string category)
    {
        ProductListResponse? productListResponse = null;

        HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync($"category/{category}");
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            productListResponse = JsonSerializer.Deserialize<ProductListResponse>(content);
        }

        return productListResponse;
    }
}