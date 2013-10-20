namespace Organigram.Specs
{
    using System.Net.Http;

    using Organigram.Api;

    using Xunit;

    using HttpClientFactory = Organigram.Specs.LibraryCandidates.HttpClientFactory;

    public static class OrganigramHttpClientFactory
    {
        public static HttpClient Create()
        {
            return HttpClientFactory.Create(
                "http://localhost:9876", 
                c => new Bootstrap().Configure(c));
        }
    }

    public class OrganigramApisTests
    {
        [Fact]
        public void OrganigramsApi_GetRequest_ReturnsSuccessStatusCode()
        {
            using (var client = OrganigramHttpClientFactory.Create())
            {
                var response = client.GetAsync("/organigrams").Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }
    }
}