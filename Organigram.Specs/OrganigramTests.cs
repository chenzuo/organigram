namespace Organigram.Specs
{
    using Xunit;

    public class OrganigramApisTests
    {
        [Fact]
        public void OrganigramsApi_GetOrganigramsAuthenticated_ReturnsSuccessStatusCode()
        {
            using (var organigramApi = new OrganigramApiTester(true))
            {
                var response = organigramApi.Client.GetAsync("/organigrams").Result;

                Assert.True(
                    response.IsSuccessStatusCode,
                    "Actual status code: " + response.StatusCode);
            }
        }

        [Fact]
        public void OrganigramsApi_GetOrganigramsUnauthenticated_ReturnsUnauthorizedStatusCode()
        {
            using (var organigramApi = new OrganigramApiTester(false))
            {
                var response = organigramApi.Client.GetAsync("/organigrams").Result;
                Assert.Equal(401, (int)response.StatusCode);                    
            }
        }
    }
}