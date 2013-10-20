using Xunit;

namespace Organigram.Specs
{
    using System.Net.Http;

    public class OrganigramTests
    {
        [Fact]
        public void OrganigramsApi_GetRequest_ReturnsSuccessStatusCode()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("").Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status";
            }
        }
    }
}