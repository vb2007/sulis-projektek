using System.Net;
using System.Text.Json;
using FluentAssertions;
using RestSharp;

namespace ApiTest_VB
{
    public class FakeApiTests
    {
        private const string _baseUrl = "https://fakerestapi.azurewebsites.net/api/v1/Books";
        private RestClient _client;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [Description("Searches a random book.")]
        public void SearchBooks()
        {
            
        }
    }
}
